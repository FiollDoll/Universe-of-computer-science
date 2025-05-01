using UnityEngine;

[System.Serializable]
public class LevelStep
{
    public string stepName;
    public Enums.LevelType lvlType;
}

[System.Serializable]
public class TextStep
{
    public string stepName;
    public string textName, textDescription;
    public Sprite image;
}