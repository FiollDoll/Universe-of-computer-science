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

    // Сцена игры
    [Header("Main")] 
    [SerializeField] private TextMeshProUGUI textLvlName;
    [SerializeField] private Button buttonNext, buttonBack;

    // LevelType - TextLevel
    [Header("TextLevel")] 
    [SerializeField] private GameObject lvlInfoMenu;

    [SerializeField] private TextMeshProUGUI lvlInfo;
    [SerializeField] private Image lvlImage;

    // LevelType - RightAnswerLevel
    [Header("RightAnswerLevel")] 
    [SerializeField] private GameObject rightAnswerMenu;

    [SerializeField] private GameObject answerInfoMenu;
    [SerializeField] private GameObject answerButtonPrefab, answerContainer;
    [SerializeField] private TextMeshProUGUI textQuestion, textInAnswerInfo;

    // LevelType - PictureLevel
    [Header("PictureLevel")] 
    [SerializeField] private GameObject pictureMenu;

    [SerializeField] private GameObject firstStyle, secondStyle;
    
    // LevelType - GiveNameByPictureLevel
    [Header("GiveNameByPictureLevel")] [SerializeField]
    private GameObject GiveNameByPictureMenu;

    [SerializeField] private GameObject questionPrefab, questionsContainer;
    
    // LevelType - LogicLevel
    [Header("LogicLevel")] [SerializeField]
    private GameObject logicMenu;

    [SerializeField] private TextMeshProUGUI textLogicQuestion;
    
    private void Awake() => Instance = this;

    private void Start()
    {
        _selectedLvl = LevelManager.Instance.GetSelectedLevel();
        textLvlName.text = _selectedLvl.nameOfLevel;
        LevelManager.Instance.ActivateStep();
        UpdateButtonNextAndBack();
    }

    private void OpenArgumentMenu(string text)
    {
        answerInfoMenu.SetActive(true);
        textInAnswerInfo.text = text;
    }
    
    public void CloseArgumentMenu()
    {
        answerInfoMenu.SetActive(false);
    }

    public void CloseAllMenu()
    {
        lvlInfoMenu?.SetActive(false);
        rightAnswerMenu?.SetActive(false);
        pictureMenu?.SetActive(false);
        GiveNameByPictureMenu?.SetActive(false);
        logicMenu?.SetActive(false);
    }

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
            (_selectedGNBPS.picturesAndNames[n], _selectedGNBPS.picturesAndNames[k]) = (_selectedGNBPS.picturesAndNames[k],_selectedGNBPS.picturesAndNames[n]);
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
            obj.transform.Find("ButtonCheck").GetComponent<Button>().onClick.AddListener(() => CheckQuestion(obj, totalPictureAndName));
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
    
    /// <summary>
    /// Обновление кнопок вперёд - назад
    /// </summary>
    public bool UpdateButtonNextAndBack()
    {
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
        UpdateButtonNextAndBack();
    }

    public void ExitFromLvl() => SceneManager.LoadScene(0);
}