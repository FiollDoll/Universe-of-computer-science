namespace Universe_of_computer_science;

public partial class StartLessonForm : Form
{
    private string _selectedLesson;
    private LessonMode _selectedMode;
    public enum LessonMode {Any, Frames, Keyboard}
    
    public StartLessonForm(string nameLesson, LessonMode lessonMode)
    {
        _selectedLesson = nameLesson;
        _selectedMode = lessonMode;
        InitializeComponent();
    }
    
    private void OpenNewForm(Form form)
    {
        form.StartPosition = FormStartPosition.Manual;
        form.Location = this.Location; // Назначение локации изначальной  формы
        form.FormClosed += (s, args) => this.Close(); // Чтобы всё грамотно закрывалось
        this.Hide();
        form.Show();
    }
    
    private void buttonReturn_Click(object sender, EventArgs e)
    {
        MainForm mainForm = new MainForm();
        OpenNewForm(mainForm);
    }

    private void buttonStart_Click(object sender, EventArgs e)
    {
        
    }
}