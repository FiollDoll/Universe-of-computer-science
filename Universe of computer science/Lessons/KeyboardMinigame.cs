namespace Universe_of_computer_science.Lessons;

public partial class KeyboardMinigame : Form, ILessonManager
{
    public Lesson totalLesson { get; set; }
    public Dictionary<string, Lesson> allLessons { get; set; }
    
    public KeyboardMinigame()
    {
        InitializeComponent();
    }
    
    public Lesson FindLesson()
    {
        return null;
    }

    public void SetStartLessonSettings()
    {
        
    }
}