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
    public string textName;
    [TextArea(0, 10)] public string textDescription;
    public Sprite image;
}