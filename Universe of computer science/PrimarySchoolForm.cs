namespace Universe_of_computer_science;

public partial class PrimarySchoolForm : Form
{
    public PrimarySchoolForm()
    {
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
    
    private void ButtonReturn_Click(object sender, EventArgs e)
    {
        MainForm mainForm = new MainForm();
        OpenNewForm(mainForm);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        StartLessonForm startLessonForm = new StartLessonForm("rulesInCabinet", StartLessonForm.LessonMode.Frames);
        OpenNewForm(startLessonForm);
    }
}