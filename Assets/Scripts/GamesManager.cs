using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public static GamesManager Instance { get; private set; }
    private Level _selectedLvl;
    private RightAnswerStep _selectedRAS;
    private GiveNameByPictureStep _selectedGNBPS;
    private LogicStep _selectedLogicStep;
    private int _selectedPage = 1;

    // Сцена игры
    [Header("Main")] [SerializeField] private TextMeshProUGUI textLvlName;
    [SerializeField] private TextMeshProUGUI textPages;
    [SerializeField] private Button buttonNext, buttonBack;

    // LevelType - TextLevel
    [Header("TextLevel")] [SerializeField] private GameObject lvlInfoMenu;

    [SerializeField] private TextMeshProUGUI lvlInfo;
    [SerializeField] private Image lvlImage;

    // LevelType - RightAnswerLevel
    [Header("RightAnswerLevel")] [SerializeField]
    private GameObject rightAnswerMenu;

    [SerializeField] private GameObject answerInfoMenu;
    [SerializeField] private GameObject answerButtonPrefab, answerContainer;
    [SerializeField] private TextMeshProUGUI textQuestion, textInAnswerInfo;

    // LevelType - PictureLevel
    [Header("PictureLevel")] [SerializeField]
    private GameObject pictureMenu;

    [SerializeField] private GameObject firstStyle, secondStyle;

    // LevelType - GiveNameByPictureLevel
    [Header("GiveNameByPictureLevel")] [SerializeField]
    private GameObject GiveNameByPictureMenu;

    [SerializeField] private GameObject questionPrefab, questionsContainer;

    // LevelType - LogicLevel
    [Header("LogicLevel")] [SerializeField]
    private GameObject logicMenu;

    [SerializeField] private TextMeshProUGUI textLogicQuestion;

    // LevelType - ExecutorLevel
    [Header("ExecutorLevel")] [SerializeField]
    private GameObject executorMenu;

    [SerializeField] private GameObject mapPlace;
    private Executor _transporter;
    [SerializeField] private TextMeshProUGUI actionDisplay, textResult;
    private List<string> _actionList = new List<string>();
    private float _currentAngle = 0f; // Текущий угол направления

    private void Awake() => Instance = this;

    private void Start()
    {
        LevelManager.Instance.stepIdx = 0;
        _selectedLvl = LevelManager.Instance.GetSelectedLevel();
        textLvlName.text = _selectedLvl.nameOfLevel;
        LevelManager.Instance.ActivateStep();
        UpdateButtonNextAndBack();
    }

    /// <summary>
    /// Обновление кнопок вперёд - назад
    /// </summary>
    public bool UpdateButtonNextAndBack()
    {
        textPages.text = _selectedPage + "/" + _selectedLvl.levelSteps.Length;
        buttonNext.interactable = true;
        buttonBack.interactable = true;
        if (LevelManager.Instance.stepIdx == (_selectedLvl.levelSteps.Length - 1))
            buttonNext.interactable = false;
        if (LevelManager.Instance.stepIdx == 0)
            buttonBack.interactable = false;

        return buttonNext.interactable; // Можно ли дальше?
    }

    /// <summary>
    /// Передвижение кнопками вперёд - назад
    /// </summary>
    /// <param name="modif"></param>
    public void MoveOnSteps(int modif)
    {
        LevelManager.Instance.stepIdx += modif;
        LevelManager.Instance.ActivateStep();
        _selectedPage += modif;
        UpdateButtonNextAndBack();
    }

    public void ExitFromLvl() => SceneManager.LoadScene(0);

    private void OpenArgumentMenu(string text)
    {
        answerInfoMenu.SetActive(true);
        textInAnswerInfo.text = text;
    }

    public void CloseArgumentMenu() => answerInfoMenu.SetActive(false);

    public void CloseAllMenu()
    {
        lvlInfoMenu?.SetActive(false);
        rightAnswerMenu?.SetActive(false);
        pictureMenu?.SetActive(false);
        GiveNameByPictureMenu?.SetActive(false);
        logicMenu?.SetActive(false);
        executorMenu?.SetActive(false);
    }

    #region SimpleLevels

    /// <summary>
    /// Открытие меню из типа TextLevel
    /// </summary>
    /// <param name="textStep"></param>
    public void ActivateLvlInfoMenu(TextStep textStep)
    {
        lvlInfoMenu.SetActive(true);
        lvlInfo.text = textStep.textDescription;
        lvlImage.sprite = textStep.image;
    }

    /// <summary>
    /// Открытие меню из типа PictureLevel
    /// </summary>
    /// <param name="pictureStep"></param>
    public void ActivatePictureMenu(PictureStep pictureStep)
    {
        pictureMenu.SetActive(true);
        secondStyle.SetActive(false);
        firstStyle.SetActive(false);
        if (pictureStep.secondPicture != null) // Значит второй стиль
        {
            secondStyle.SetActive(true);
            secondStyle.transform.Find("Image").GetComponent<Image>().sprite = pictureStep.firstPicture;
            secondStyle.transform.Find("Image1").GetComponent<Image>().sprite = pictureStep.secondPicture;
        }
        else
        {
            firstStyle.SetActive(true);
            firstStyle.transform.Find("Image").GetComponent<Image>().sprite = pictureStep.firstPicture;
        }
    }

    #endregion

    #region Right answer

    /// <summary>
    /// Открытие меню из типа RightAnswerLevel
    /// </summary>
    /// <param name="rightAnswerStep"></param>
    public void ActivateRightAnswerMenu(RightAnswerStep rightAnswerStep)
    {
        rightAnswerMenu.SetActive(true);
        textQuestion.text = rightAnswerStep.textQuestion;
        _selectedRAS = rightAnswerStep;
        System.Random rng = new System.Random();

        // Рандомно перемешиваем
        int n = _selectedRAS.answers.Count;

        while (n > 1)
        {
            int k = rng.Next(n--);
            (_selectedRAS.answers[n], _selectedRAS.answers[k]) = (_selectedRAS.answers[k], _selectedRAS.answers[n]);
        }

        GenerateAnswers();
    }

    /// <summary>
    /// Генерируем ответы
    /// </summary>
    private void GenerateAnswers(bool win = false)
    {
        foreach (Transform child in answerContainer.transform)
            Destroy(child.gameObject);

        foreach (Answer answer in _selectedRAS.answers)
        {
            GameObject newButtonAnswer = Instantiate(answerButtonPrefab, Vector3.zero, Quaternion.identity,
                answerContainer.transform);
            newButtonAnswer.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = answer.answerText;
            Answer newAnswer = answer;
            newButtonAnswer.GetComponent<Button>().onClick.AddListener(() => ChoiceAnswer(newAnswer));

            // Если уже проверено
            if (win)
                newButtonAnswer.GetComponent<Image>().color = answer.answerIsRight
                    ? new Color(179f / 255f, 252f / 255f, 176f / 255f)
                    : new Color(252f / 255f, 176f / 255f, 176f / 255f);
        }
    }

    /// <summary>
    /// Выбор любого ответа, а после проверка - правильный или нет
    /// </summary>
    /// <param name="idx"></param>
    public void ChoiceAnswer(Answer answer)
    {
        OpenArgumentMenu(answer.argumentAnswer);
        if (answer.answerIsRight)
            GenerateAnswers(true);
    }

    #endregion

    #region GiveNameByPicture

    /// <summary>
    /// Открытие меню из типа GiveNameByPictureLevel
    /// </summary>
    /// <param name="giveName"></param>
    public void ActivateGiveNameByPictureMenu(GiveNameByPictureStep giveName)
    {
        GiveNameByPictureMenu.SetActive(true);
        _selectedGNBPS = giveName;

        System.Random rng = new System.Random();

        // Рандомно перемешиваем
        int n = _selectedGNBPS.picturesAndNames.Count;

        while (n > 1)
        {
            int k = rng.Next(n--);
            (_selectedGNBPS.picturesAndNames[n], _selectedGNBPS.picturesAndNames[k]) = (
                _selectedGNBPS.picturesAndNames[k], _selectedGNBPS.picturesAndNames[n]);
        }

        GenerateQuestionsToPicture();
    }

    public void GenerateQuestionsToPicture()
    {
        foreach (Transform child in questionsContainer.transform)
            Destroy(child.gameObject);

        foreach (PictureAndName pictureAndName in _selectedGNBPS.picturesAndNames)
        {
            GameObject obj = Instantiate(questionPrefab, Vector3.zero, Quaternion.identity,
                questionsContainer.transform);

            obj.GetComponent<Image>().sprite = pictureAndName.thingPicture;
            PictureAndName totalPictureAndName = pictureAndName;
            obj.transform.Find("ButtonCheck").GetComponent<Button>().onClick
                .AddListener(() => CheckQuestion(obj, totalPictureAndName));
        }
    }

    private void CheckQuestion(GameObject obj, PictureAndName pictureAndName)
    {
        if (pictureAndName.thingName == obj.transform.Find("InputField").GetComponent<TMP_InputField>().text)
        {
            pictureAndName.end = true;
            obj.transform.Find("ButtonCheck").GetComponent<Button>().interactable = false;
            obj.transform.Find("InputField").GetComponent<TMP_InputField>().interactable = false;
        }
    }

    #endregion

    #region LogicLevel

    public void ActivateLogicMenu(LogicStep logicStep)
    {
        logicMenu.SetActive(true);
        textLogicQuestion.text = logicStep.question.question;
        _selectedLogicStep = logicStep;
        UpdateButtonNextAndBack();
    }

    public void CheckLogicAnswer(bool state)
    {
        bool win = state == _selectedLogicStep.question.trueOrFalse;
        OpenArgumentMenu(win
            ? _selectedLogicStep.question.argumentQuestionTrue
            : _selectedLogicStep.question.argumentQuestionFalse);
    }

    #endregion

    #region ExecutorLevel

    public void ActivateExecutorMenu(ExecutorStep executorStep)
    {
        executorMenu.SetActive(true);
        foreach (Transform child in mapPlace.transform)
            Destroy(child.gameObject);

        var obj = Instantiate(executorStep.mapPrefab, Vector3.zero, Quaternion.identity, mapPlace.transform);
        _transporter = obj?.transform.Find("executor").GetComponent<Executor>();
        _currentAngle = 0;
        _actionList = new List<string>();
        UpdateActionDisplay();
    }

    public void MoveExecutor(int mode)
    {
        Vector3 direction = Vector3.zero;
        Vector3 rotation = Vector3.zero;

        switch (mode)
        {
            case 0: // Вперёд
                direction = Quaternion.Euler(0, 0, _currentAngle) * Vector3.up;
                break;
            case 1: // Назад
                direction = Quaternion.Euler(0, 0, _currentAngle) * Vector3.down;
                break;
            case 2: // Влево
                _currentAngle += 90f;
                rotation = new Vector3(0f, 0f, 90f);
                direction = Vector3.zero;
                break;
            case 3: // Вправо
                _currentAngle -= 90f;
                rotation = new Vector3(0f, 0f, -90f);
                direction = Vector3.zero;
                break;
            default:
                direction = Vector3.zero;
                rotation = Vector3.zero;
                break;
        }

        _transporter.AddAction(direction);
        _transporter.AddActionRot(rotation);
        _actionList.Add(mode switch
        {
            0 => "Вперёд",
            1 => "Назад",
            2 => "Влево",
            3 => "Вправо"
        });

        UpdateActionDisplay();
    }

    public void StartTransporter()
    {
        _transporter.transform.position = Vector3.zero;
        _currentAngle = 0;
        _transporter.StartActions();
    }

    public void StopTransporter()
    {
        _transporter.StopActions();
        _transporter.transform.position = Vector3.zero;
        _currentAngle = 0;
    }

    private void UpdateActionDisplay() => actionDisplay.text = string.Join(" > ", _actionList);

    public void DeleteLastAction()
    {
        _transporter.DeleteLastAction();
        _actionList.RemoveAt(_actionList.Count - 1);
        UpdateActionDisplay();
    }

    public void EndExecutor(bool win)
    {
        textResult.text = win ? "Ваш алгоритм выполнен правильно! Вы победили!" : "Ваш алгоритм содержит ошибку.";
    }

    #endregion
}