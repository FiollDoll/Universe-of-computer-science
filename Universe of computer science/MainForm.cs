namespace Universe_of_computer_science;

public partial class MainForm : Form
{
    public MainForm()
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
    
    private void label1_Click(object sender, EventArgs e)
    {
        
    }

    private void FirstModeButton_Click(object sender, EventArgs e)
    {
        PrimarySchoolForm newPrimarySchoolForm = new PrimarySchoolForm();
        OpenNewForm(newPrimarySchoolForm);
    }

    private void SecondModeButton_Click(object sender, EventArgs e)
    {
        HighSchoolForm highSchoolForm = new HighSchoolForm();
        OpenNewForm(highSchoolForm);
    }

    private void AboutButton_Click(object sender, EventArgs e) => this.infoMenu.Visible = true;

    private void CloseInfoButton_Click(object sender, EventArgs e) => this.infoMenu.Visible = false;

}