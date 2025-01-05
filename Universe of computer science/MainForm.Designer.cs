namespace Universe_of_computer_science;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        label1 = new System.Windows.Forms.Label();
        FirstModeButton = new System.Windows.Forms.Button();
        SecondModeButton = new System.Windows.Forms.Button();
        disableSoundButton = new System.Windows.Forms.Button();
        aboutButton = new System.Windows.Forms.Button();
        infoMenu = new System.Windows.Forms.GroupBox();
        CloseInfoButton = new System.Windows.Forms.Button();
        label2 = new System.Windows.Forms.Label();
        infoMenu.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
        label1.Font = new System.Drawing.Font("Hotel De Paris Xe", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        label1.Location = new System.Drawing.Point(200, 26);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(507, 133);
        label1.TabIndex = 0;
        label1.Text = "ВСЕЛЕННАЯ ИНФОРМАТИКИ";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        label1.Click += label1_Click;
        // 
        // FirstModeButton
        // 
        FirstModeButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        FirstModeButton.Location = new System.Drawing.Point(241, 216);
        FirstModeButton.Name = "FirstModeButton";
        FirstModeButton.Size = new System.Drawing.Size(142, 161);
        FirstModeButton.TabIndex = 1;
        FirstModeButton.Text = "Начальная школа\r\n\r\n1-4 год обучения";
        FirstModeButton.UseVisualStyleBackColor = true;
        FirstModeButton.Click += FirstModeButton_Click;
        // 
        // SecondModeButton
        // 
        SecondModeButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        SecondModeButton.Location = new System.Drawing.Point(508, 216);
        SecondModeButton.Name = "SecondModeButton";
        SecondModeButton.Size = new System.Drawing.Size(142, 161);
        SecondModeButton.TabIndex = 2;
        SecondModeButton.Text = "Средняя школа\r\n\r\n5-9 год обучения";
        SecondModeButton.UseVisualStyleBackColor = true;
        SecondModeButton.Click += SecondModeButton_Click;
        // 
        // disableSoundButton
        // 
        disableSoundButton.Location = new System.Drawing.Point(10, 9);
        disableSoundButton.Name = "disableSoundButton";
        disableSoundButton.Size = new System.Drawing.Size(36, 37);
        disableSoundButton.TabIndex = 3;
        disableSoundButton.Text = "button1";
        disableSoundButton.UseVisualStyleBackColor = true;
        // 
        // aboutButton
        // 
        aboutButton.Location = new System.Drawing.Point(9, 463);
        aboutButton.Name = "aboutButton";
        aboutButton.Size = new System.Drawing.Size(115, 20);
        aboutButton.TabIndex = 4;
        aboutButton.Text = "Информация";
        aboutButton.UseVisualStyleBackColor = true;
        aboutButton.Click += AboutButton_Click;
        // 
        // infoMenu
        // 
        infoMenu.BackColor = System.Drawing.SystemColors.ControlLight;
        infoMenu.Controls.Add(CloseInfoButton);
        infoMenu.Controls.Add(label2);
        infoMenu.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        infoMenu.Location = new System.Drawing.Point(230, 50);
        infoMenu.Name = "infoMenu";
        infoMenu.Size = new System.Drawing.Size(420, 383);
        infoMenu.TabIndex = 5;
        infoMenu.TabStop = false;
        infoMenu.Text = "Информация";
        infoMenu.Visible = false;
        // 
        // CloseInfoButton
        // 
        CloseInfoButton.Location = new System.Drawing.Point(382, 19);
        CloseInfoButton.Name = "CloseInfoButton";
        CloseInfoButton.Size = new System.Drawing.Size(32, 28);
        CloseInfoButton.TabIndex = 1;
        CloseInfoButton.Text = "X";
        CloseInfoButton.UseVisualStyleBackColor = true;
        CloseInfoButton.Click += CloseInfoButton_Click;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(15, 50);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(399, 309);
        label2.TabIndex = 0;
        label2.Text = "Информация о приложении";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        ClientSize = new System.Drawing.Size(909, 488);
        Controls.Add(infoMenu);
        Controls.Add(aboutButton);
        Controls.Add(disableSoundButton);
        Controls.Add(SecondModeButton);
        Controls.Add(FirstModeButton);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        ShowIcon = false;
        Text = "Вселенная информатики";
        infoMenu.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button CloseInfoButton;

    private System.Windows.Forms.GroupBox infoMenu;
    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button aboutButton;

    private System.Windows.Forms.Button disableSoundButton;

    private System.Windows.Forms.Button FirstModeButton;

    private System.Windows.Forms.Button SecondModeButton;

    private System.Windows.Forms.Label label1;

    #endregion
}