using System.Collections.Generic;
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

[System.Serializable]
public class RightAnswerStep
{
    public string stepName;
    public string textQuestion;
    public List<Answer> answers = new List<Answer>();
}

[System.Serializable]
public class Answer
{
    [TextArea(0, 10)] public string answerText;
    [TextArea(0, 10)] public string argumentAnswer;
    public bool answerIsRight;
}

[System.Serializable]
public class PictureStep
{
    public string stepName;
    public Sprite firstPicture, secondPicture;
}
