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

    private Dictionary<string, Theme> _dictAllThemes = new Dictionary<string, Theme>();
    private Dictionary<string, TextStep> _dictTextSteps = new Dictionary<string, TextStep>();

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
        
    }

    private TextStep GetTextStep(string stepName)
    {
        return _dictTextSteps[stepName];
    }

    public Level GetSelectedLevel()
    {
        return selectedLvl;
    }

    public void ActivateLevel(Theme theme, Level lvl)
    {
        selectedTheme = theme;
        selectedLvl = lvl;
        if (theme.themeCategory == Enums.Category.FirstToFourthClass)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(2);
    }

    public void ActivateStep()
    {
        selectedStep = selectedLvl.levelSteps[stepIdx];
        switch (selectedStep.lvlType)
        {
            case Enums.LevelType.TextLevel:
                TextStep textStep = GetTextStep(selectedStep.stepName);
                GamesManager.Instance.ActivateLvlInfoMenu(textStep);
                break;
        }
    }
}
