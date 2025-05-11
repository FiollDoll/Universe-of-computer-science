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
    public Sprite firstPicture;
    [TextArea(0, 10)] public string textPicture;
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
    [HideInInspector] public bool end;
}

[System.Serializable]
public class LogicStep
{
    public string stepName;
    public LogicQuestion question;
}

[System.Serializable]
public class LogicQuestion
{
    [TextArea(0, 10)] public string question;
    [TextArea(0, 10)] public string argumentQuestionTrue, argumentQuestionFalse;
    public bool trueOrFalse;
}

[System.Serializable]
public class ExecutorStep
{
    public string stepName;
    public GameObject mapPrefab;
}

[System.Serializable]
public class WiresStep
{
    public string stepName;
    public List<Wire> wires = new List<Wire>();

    public WiresStep(WiresStep wiresStep)
    {
        stepName = wiresStep.stepName;
        foreach (Wire wire in wiresStep.wires)
            wires.Add(new Wire(wire)); // Создаем копию каждого wire
    }

    public void ShuffleWires()
    {
        ShuffleField(wires, "word");
        ShuffleField(wires, "wordArgument");
    }

    private void ShuffleField(List<Wire> wires, string fieldName)
    {
        List<string> fieldValues = new List<string>();

        foreach (var wire in wires)
            fieldValues.Add(fieldName == "word" ? wire.word : wire.wordArgument);

        // Перемешиваем значения
        System.Random random = new System.Random();
        for (int i = 0; i < fieldValues.Count; i++)
        {
            int j = random.Next(i, fieldValues.Count);
            (fieldValues[i], fieldValues[j]) = (fieldValues[j], fieldValues[i]);
        }

        for (int i = 0; i < wires.Count; i++)
        {
            if (fieldName == "word")
                wires[i].word = fieldValues[i];
            else
                wires[i].wordArgument = fieldValues[i];
        }
    }
}

[System.Serializable]
public class Wire
{
    [HideInInspector] public UnityEngine.UI.Button buttonWord, buttonArg;
    public int id;
    public string word;
    public string wordArgument;

    public Wire()
    {
    }

    public Wire(Wire wire)
    {
        id = wire.id;
        word = wire.word;
        wordArgument = wire.wordArgument;
    }
}