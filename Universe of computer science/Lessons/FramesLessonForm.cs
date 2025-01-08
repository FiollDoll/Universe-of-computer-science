namespace Universe_of_computer_science.Lessons;

public partial class FramesLessonForm : Form, ILessonManager
{
    public Lesson totalLesson { get; set; }
    public Dictionary<string, Lesson> allLessons { get; set; }
    
    /// <summary>
    /// Форма, в которой обучение происходит за счёт кадров и текста.
    /// </summary>
    public FramesLessonForm()
    {
        InitializeComponent();
        allLessons = new Dictionary<string, Lesson>
        {
            {"", new Lesson()},
            {"", new Lesson()},
            {"", new Lesson()},
        };

    }

    public Lesson FindLesson()
    {
        return null;
    }

    public void SetStartLessonSettings()
    {
        
    }
}