using UnityEngine;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance {get; private set;}

    [Header("ThemesAndLevels")]
    public List<Theme> themes = new List<Theme>();
    private Dictionary<string, Theme> _dictAllThemes = new Dictionary<string, Theme>();

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
    }
}
