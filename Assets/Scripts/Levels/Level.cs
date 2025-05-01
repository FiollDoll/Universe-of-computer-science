using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Level
{
    public string nameOfLevel;
    public Sprite preiconOfLevel;
    [TextArea(0, 10)] public string descriptionOfLevel;
    public LevelStep[] levelSteps = new LevelStep[0];
}