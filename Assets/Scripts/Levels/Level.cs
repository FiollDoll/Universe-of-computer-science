using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Theme
{
    public string nameOfTheme;
    public List<Level> levelsInTheme = new List<Level>();
    public Enums.Category themeCategory;
}

[System.Serializable]
public class Level
{
    public string nameOfLevel;
    public Sprite preiconOfLevel;
    [TextArea(0, 10)] public string descriptionOfLevel;
}
