namespace Universe_of_computer_science.Lessons;

public partial class FramesLessonForm : Form
{
    public Lesson totalLesson;
    public Dictionary<string, Lesson> allLessons;

    /// <summary>
    /// Форма, в которой обучение происходит за счёт кадров и текста.
    /// </summary>
    public FramesLessonForm(string selectedLesson)
    {
        InitializeComponent();
    }
}