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

[System.Serializable]
public class GiveNameByPictureStep
{
    public string stepName;
    public List<PictureAndName> picturesAndNames = new List<PictureAndName>();
    
    /// <summary>
    /// Проверка - завершены ли все вопросы?
    /// </summary>
    /// <returns></returns>
    public bool CheckEndAllQuestions()
    {
        bool allQuestionsEnd = true;
        foreach (PictureAndName pictureAndName in picturesAndNames)
        {
            if (!pictureAndName.end)
            {
                allQuestionsEnd = false;
                break;
            }
        }

        return allQuestionsEnd;
    }
}

[System.Serializable]
public class PictureAndName
{
    public string thingName;
    public Sprite thingPicture;
    public bool end;
}
