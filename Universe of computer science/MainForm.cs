namespace Universe_of_computer_science;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
    }

    private void label1_Click(object sender, EventArgs e)
    {
        
    }

    private void FirstModeButton_Click(object sender, EventArgs e)
    {
        PrimarySchoolForm newPrimarySchoolForm = new PrimarySchoolForm();
        newPrimarySchoolForm.StartPosition = FormStartPosition.Manual;
        newPrimarySchoolForm.Location = this.Location; // Назначение локации изначальной  формы
        newPrimarySchoolForm.FormClosed += (s, args) => this.Close(); // Чтобы всё грамотно закрывалось
        this.Hide();

        newPrimarySchoolForm.Show();
    }

    private void SecondModeButton_Click(object sender, EventArgs e)
    {
        HighSchoolForm highSchoolForm = new HighSchoolForm();
        highSchoolForm.StartPosition = FormStartPosition.Manual;
        highSchoolForm.Location = this.Location; // Назначение локации изначальной  формы
        highSchoolForm.FormClosed += (s, args) => this.Close(); // Чтобы всё грамотно закрывалось
        this.Hide();

        highSchoolForm.Show();
    }

    private void AboutButton_Click(object sender, EventArgs e) => this.infoMenu.Visible = true;

    private void CloseInfoButton_Click(object sender, EventArgs e) => this.infoMenu.Visible = false;

}