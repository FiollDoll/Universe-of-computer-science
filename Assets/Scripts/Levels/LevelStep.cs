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
    public Answer[] answers = new Answer[0];
}

[System.Serializable]
public class Answer
{
    [TextArea(0, 10)] public string answerText;
    [TextArea(0, 10)] public string argumentAnswer;
    public bool answerIsRight;
}
