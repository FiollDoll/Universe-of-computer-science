namespace Universe_of_computer_science;

public partial class PrimarySchoolForm : Form
{
    public PrimarySchoolForm()
    {
        InitializeComponent();
    }

    private void ButtonReturn_Click(object sender, EventArgs e)
    {
        MainForm mainForm = new MainForm();
        mainForm.StartPosition = FormStartPosition.Manual;
        mainForm.Location = this.Location; // Назначение локации изначальной  формы
        mainForm.FormClosed += (s, args) => this.Close(); // Чтобы всё грамотно закрывалось
        this.Hide();

        mainForm.Show();
    }
}