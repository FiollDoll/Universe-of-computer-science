namespace Universe_of_computer_science;

public class Lesson
{
    public string LessonName;
    public string LessonDescription;
    public Bitmap FirstImage, SecondImage;

    public Lesson()
    {
        
    }
    
    public Lesson(string lessonName, string lessonDescription)
    {
        LessonName = lessonName;
        LessonDescription = lessonDescription;
    }
    
    public Lesson(string lessonName, string lessonDescription, Bitmap firstImage)
    {
        LessonName = lessonName;
        LessonDescription = lessonDescription;
        FirstImage = firstImage;
    }
    
    public Lesson(string lessonName, string lessonDescription, Bitmap firstImage, Bitmap secondImage)
    {
        LessonName = lessonName;
        LessonDescription = lessonDescription;
        FirstImage = firstImage;
        SecondImage = secondImage;
    }
}

public interface ILessonManager
{
    public Lesson totalLesson { get; set; }
    public Dictionary<string, Lesson> allLessons { get; set; }
    
    public Lesson FindLesson();
    public void SetStartLessonSettings();
}