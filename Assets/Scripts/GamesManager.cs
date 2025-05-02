using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GamesManager : MonoBehaviour
{
    public static GamesManager Instance {get; private set;}
    private Level selectedLvl;
    private RightAnswerStep selectedRAS;

    // Сцена игры
    [Header("Main")]
    [SerializeField] private TextMeshProUGUI textLvlName;
    [SerializeField] private Button buttonNext, buttonBack;

    // LevelType - TextLevel
    [Header("TextLevel")]
    [SerializeField] private GameObject lvlInfoMenu;
    [SerializeField] private TextMeshProUGUI lvlInfo;
    [SerializeField] private Image lvlImage;
    
    // LevelType - RightAnswer
    [Header("RightAnswerLevel")] 
    [SerializeField] private GameObject rightAnswerMenu;

    [SerializeField] private GameObject answerInfoMenu;
    [SerializeField] private GameObject answerButtonPrefab, answerContainer;
    [SerializeField] private TextMeshProUGUI textQuestion, textInAnswerInfo;
    private Color rightColor, wrongColor;
    
    private void Awake() => Instance = this;

    private void Start()
    {
        selectedLvl = LevelManager.Instance.GetSelectedLevel();
        textLvlName.text = selectedLvl.nameOfLevel;
        LevelManager.Instance.ActivateStep();
        UpdateButtonNextAndBack();
    }

    public void CloseAllMenu()
    {
        lvlInfoMenu.SetActive(false);
        rightAnswerMenu.SetActive(false);
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
        buttonNext.interactable = false;
        textQuestion.text = rightAnswerStep.textQuestion;
        selectedRAS = rightAnswerStep;
        
        GenerateAnswers();
    }
    
    /// <summary>
    /// Генерируем ответы
    /// </summary>
    public void GenerateAnswers()
    {
        foreach (Transform child in answerContainer.transform)
            Destroy(child.gameObject);
            
        foreach (Answer answer in selectedRAS.answers)
        {
            GameObject newButtonAnswer = Instantiate(answerButtonPrefab, Vector3.zero, Quaternion.identity,
                answerContainer.transform); 
            newButtonAnswer.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = answer.answerText;
            Answer newAnswer = answer;
            newButtonAnswer.GetComponent<Button>().onClick.AddListener(() => ChoiceAnswer(newAnswer));
            
            // Если уже проверено
            if (buttonNext.interactable)
                newButtonAnswer.GetComponent<Image>().color = answer.answerIsRight ? 
                    new Color(179f / 255f, 252f / 255f, 176f / 255f) : new Color(252f / 255f, 176f / 255f, 176f / 255f);
        }
    }
    
    /// <summary>
    /// Выбор любого ответа, а после проверка - правильный или нет
    /// </summary>
    /// <param name="idx"></param>
    public void ChoiceAnswer(Answer answer)
    {
        answerInfoMenu.SetActive(true);
        textInAnswerInfo.text = answer.argumentAnswer;
        if (answer.answerIsRight)
        {
            buttonNext.interactable = true; // Активируем, т.к не может быть последним
            GenerateAnswers();
        }
    }

    public void CloseAnswerInfoMenu()
    {
        // Ответили мы правильно или нет
        if (!buttonNext.interactable)
            GenerateAnswers();
        
        answerInfoMenu.SetActive(false);
    }
    
    /// <summary>
    /// Обновление кнопок вперёд - назад
    /// </summary>
    public bool UpdateButtonNextAndBack()
    {
        buttonNext.interactable = true;
        buttonBack.interactable = true;
        if (LevelManager.Instance.stepIdx == (selectedLvl.levelSteps.Length - 1))
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
