using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance {get; private set;}
    
    // Выбранное. Быстрый доступ
    private Theme selectedTheme;
    private Level selectedLvl;
    private LevelStep selectedStep;
    public int stepIdx;
    
    // Темы и уровни
    [Header("ThemesAndLevels")]
    public List<Theme> themes = new List<Theme>();
    public List<TextStep> textSteps = new List<TextStep>();
    public List<RightAnswerStep> rightAnswerSteps = new List<RightAnswerStep>();


    private Dictionary<string, Theme> _dictAllThemes = new Dictionary<string, Theme>();
    private Dictionary<string, TextStep> _dictTextSteps = new Dictionary<string, TextStep>();
    private Dictionary<string, RightAnswerStep> _dictRightAnswerSteps = new Dictionary<string, RightAnswerStep>();

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
        
    }
    
    private TextStep GetTextStep(string stepName)
    {
        return _dictTextSteps[stepName];
    }
    
    private RightAnswerStep GetRightAnwerStep(string stepName)
    {
        return  _dictRightAnswerSteps[stepName];
    }
    
    /// <summary>
    /// Получить выбранный уровень(для общего доступа)
    /// </summary>
    public Level GetSelectedLevel()
    {
        return selectedLvl;
    }
    
    /// <summary>
    /// Активировать новый уровень
    /// </summary>
    /// <param name="theme"></param>
    /// <param name="lvl"></param>
    public void ActivateLevel(Theme theme, Level lvl)
    {
        selectedTheme = theme;
        selectedLvl = lvl;
        if (theme.themeCategory == Enums.Category.FirstToFourthClass)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(2);
    }
    
    /// <summary>
    /// Активировать шаг уровня
    /// </summary>
    public void ActivateStep()
    {
        GamesManager.Instance.CloseAllMenu();
        selectedStep = selectedLvl.levelSteps[stepIdx];
        switch (selectedStep.lvlType)
        {
            case Enums.LevelType.TextLevel:
                TextStep textStep = GetTextStep(selectedStep.stepName);
                GamesManager.Instance.ActivateLvlInfoMenu(textStep);
                break;
            case Enums.LevelType.RightAnswerLevel:
                RightAnswerStep answerStep = GetRightAnwerStep(selectedStep.stepName);
                GamesManager.Instance.ActivateRightAnswerMenu(answerStep);
                break;
        }
    }
}
