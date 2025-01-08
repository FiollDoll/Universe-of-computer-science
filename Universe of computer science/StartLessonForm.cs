using Universe_of_computer_science.Lessons;

namespace Universe_of_computer_science;

public partial class StartLessonForm : Form
{
    public Lesson totalLesson { get; set; }
    private string _selectedLesson;
    private LessonMode _selectedMode;

    public enum LessonMode
    {
        Any,
        Frames,
        Keyboard
    }

    public Dictionary<string, Lesson> allLessons = new Dictionary<string, Lesson>
    {
        {
            "rulesInCabinet",
            new Lesson("Правила поведения в кабинете информатики",
                "Дорогой друг!\nНа уроках информатики ты узнаешь много необходимого человеку двадцать первого века. " +
                "Постепенно ты научишься обращаться с компьютером.")
        },
        { "", new Lesson() }
    };

    public StartLessonForm(string nameLesson, LessonMode lessonMode)
    {
        _selectedLesson = nameLesson;
        _selectedMode = lessonMode;
        InitializeComponent();
        totalLesson = allLessons[_selectedLesson];
        labelName.Text = totalLesson.LessonName;
        textDescription.Text = totalLesson.LessonDescription;
        pictureBox1.Image = totalLesson.FirstImage;
        pictureBox2.Image = totalLesson.SecondImage;
    }

    private void OpenNewForm(Form form)
    {
        form.StartPosition = FormStartPosition.Manual;
        form.Location = this.Location; // Назначение локации изначальной  формы
        form.FormClosed += (s, args) => this.Close(); // Чтобы всё грамотно закрывалось
        this.Hide();
        form.Show();
    }

    private void buttonStart_Click(object sender, EventArgs e)
    {
        if (_selectedMode == LessonMode.Frames)
        {
            FramesLessonForm framesLessonForm = new FramesLessonForm(_selectedLesson);
            OpenNewForm(framesLessonForm);
        }
    }

    private void buttonReturn_Click_1(object sender, EventArgs e)
    {
        MainForm mainForm = new MainForm();
        OpenNewForm(mainForm);
    }
}