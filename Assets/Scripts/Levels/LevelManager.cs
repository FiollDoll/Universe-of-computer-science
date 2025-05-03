using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance {get; private set;}
    
    // Выбранное. Быстрый доступ
    private Theme _selectedTheme;
    private Level _selectedLvl;
    private LevelStep _selectedStep;
    public int stepIdx;
    
    // Темы и уровни
    [Header("ThemesAndLevels")]
    public List<Theme> themes = new List<Theme>();
    public List<TextStep> textSteps = new List<TextStep>();
    public List<RightAnswerStep> rightAnswerSteps = new List<RightAnswerStep>();
    public List<PictureStep> pictureSteps = new List<PictureStep>();

    private readonly Dictionary<string, Theme> _dictAllThemes = new Dictionary<string, Theme>();
    private readonly Dictionary<string, TextStep> _dictTextSteps = new Dictionary<string, TextStep>();
    private readonly Dictionary<string, RightAnswerStep> _dictRightAnswerSteps = new Dictionary<string, RightAnswerStep>();
    private readonly Dictionary<string, PictureStep> _dictPictureSteps = new Dictionary<string, PictureStep>();

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
        foreach(Theme theme in themes)
            _dictAllThemes.Add(theme.nameOfTheme, theme);

        foreach (TextStep step in textSteps)
            _dictTextSteps.Add(step.stepName, step);
        
        foreach (RightAnswerStep step in rightAnswerSteps)
            _dictRightAnswerSteps.Add(step.stepName, step);
        
        foreach (PictureStep step in pictureSteps)
            _dictPictureSteps.Add(step.stepName, step);
    }
    
    private TextStep GetTextStep(string stepName)
    {
        return _dictTextSteps[stepName];
    }
    
    private RightAnswerStep GetRightAnwerStep(string stepName)
    {
        return  _dictRightAnswerSteps[stepName];
    }

    private PictureStep GetPictureStep(string stepName)
    {
        return _dictPictureSteps[stepName];
    }
    
    /// <summary>
    /// Получить выбранный уровень(для общего доступа)
    /// </summary>
    public Level GetSelectedLevel()
    {
        return _selectedLvl;
    }
    
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
                RightAnswerStep answerStep = GetRightAnwerStep(_selectedStep.stepName);
                GamesManager.Instance.ActivateRightAnswerMenu(answerStep);
                break;
            case Enums.LevelType.PictureLevel:
                PictureStep pictureStep = GetPictureStep(_selectedStep.stepName);
                GamesManager.Instance.ActivatePictureMenu(pictureStep);
                break;
        }
    }
}
