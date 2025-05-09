using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    // Выбранное. Быстрый доступ
    private Theme _selectedTheme;
    private Level _selectedLvl;
    private LevelStep _selectedStep;
    public int stepIdx;

    // Темы и уровни
    [Header("ThemesAndLevels")] public List<Theme> themes = new List<Theme>();
    public List<TextStep> textSteps = new List<TextStep>();
    public List<RightAnswerStep> rightAnswerSteps = new List<RightAnswerStep>();
    public List<PictureStep> pictureSteps = new List<PictureStep>();
    public List<GiveNameByPictureStep> giveNameSteps = new List<GiveNameByPictureStep>();
    public List<LogicStep> logicSteps = new List<LogicStep>();
    public List<ExecutorStep> executorSteps = new List<ExecutorStep>();


    private readonly Dictionary<string, Theme> _dictAllThemes = new Dictionary<string, Theme>();
    private readonly Dictionary<string, TextStep> _dictTextSteps = new Dictionary<string, TextStep>();

    private readonly Dictionary<string, RightAnswerStep> _dictRightAnswerSteps =
        new Dictionary<string, RightAnswerStep>();

    private readonly Dictionary<string, PictureStep> _dictPictureSteps = new Dictionary<string, PictureStep>();
    private readonly Dictionary<string, GiveNameByPictureStep> _dictGiveNameSteps = new Dictionary<string, GiveNameByPictureStep>();
    private readonly Dictionary<string, LogicStep> _dictLogicSteps = new Dictionary<string, LogicStep>();
    private readonly Dictionary<string, ExecutorStep> _dictExecutorSteps = new Dictionary<string, ExecutorStep>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance == this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        foreach (Theme theme in themes)
            _dictAllThemes.Add(theme.nameOfTheme, theme);

        foreach (TextStep step in textSteps)
            _dictTextSteps.Add(step.stepName, step);

        foreach (RightAnswerStep step in rightAnswerSteps)
            _dictRightAnswerSteps.Add(step.stepName, step);

        foreach (PictureStep step in pictureSteps)
            _dictPictureSteps.Add(step.stepName, step);
        
        foreach (GiveNameByPictureStep step in giveNameSteps)
            _dictGiveNameSteps.Add(step.stepName, step);
        
        foreach (LogicStep step in logicSteps)
            _dictLogicSteps.Add(step.stepName, step);
        
        foreach (ExecutorStep step in executorSteps)
            _dictExecutorSteps.Add(step.stepName, step);
    }

    private TextStep GetTextStep(string stepName) => _dictTextSteps[stepName];
    
    private RightAnswerStep GetRightAnswerStep(string stepName) => _dictRightAnswerSteps[stepName];
    
    private PictureStep GetPictureStep(string stepName) => _dictPictureSteps[stepName];
    
    private GiveNameByPictureStep GetGiveNameStep(string stepName) => _dictGiveNameSteps[stepName];
    
    private LogicStep GetLogicStep(string stepName) => _dictLogicSteps[stepName];
    
    private ExecutorStep GetExecutorStep(string stepName) => _dictExecutorSteps[stepName];
    
    public Theme GetSelectedTheme() => _selectedTheme;
    
    public Level GetSelectedLevel() => _selectedLvl;
    

    /// <summary>
    /// Активировать новый уровень
    /// </summary>
    /// <param name="theme"></param>
    /// <param name="lvl"></param>
    public void ActivateLevel(Theme theme, Level lvl)
    {
        _selectedTheme = theme;
        _selectedLvl = lvl;
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// Активировать шаг уровня
    /// </summary>
    public void ActivateStep()
    {
        GamesManager.Instance.CloseAllMenu();
        _selectedStep = _selectedLvl.levelSteps[stepIdx];
        switch (_selectedStep.lvlType)
        {
            case Enums.LevelType.TextLevel:
                TextStep textStep = GetTextStep(_selectedStep.stepName);
                GamesManager.Instance.ActivateLvlInfoMenu(textStep);
                break;
            case Enums.LevelType.RightAnswerLevel:
                RightAnswerStep answerStep = GetRightAnswerStep(_selectedStep.stepName);
                GamesManager.Instance.ActivateRightAnswerMenu(answerStep);
                break;
            case Enums.LevelType.PictureLevel:
                PictureStep pictureStep = GetPictureStep(_selectedStep.stepName);
                GamesManager.Instance.ActivatePictureMenu(pictureStep);
                break;
            case Enums.LevelType.GiveNameByPictureLevel:
                GiveNameByPictureStep giveNameStep = GetGiveNameStep(_selectedStep.stepName);
                GamesManager.Instance.ActivateGiveNameByPictureMenu(giveNameStep);
                break;
            case Enums.LevelType.LogicLevel:
                LogicStep logicStep = GetLogicStep(_selectedStep.stepName);
                GamesManager.Instance.ActivateLogicMenu(logicStep);
                break;
            case Enums.LevelType.ExecutorLevel:
                ExecutorStep executorStep = GetExecutorStep(_selectedStep.stepName);
                GamesManager.Instance.ActivateExecutorMenu(executorStep);
                break;
        }
    }
}