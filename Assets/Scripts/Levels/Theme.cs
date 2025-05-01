using System.Collections.Generic;

[System.Serializable]
public class Theme
{
    public string nameOfTheme;
    public List<Level> levelsInTheme = new List<Level>();
    public Enums.Category themeCategory;
}
