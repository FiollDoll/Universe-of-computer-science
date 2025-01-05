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
        ThirdModeButton = new System.Windows.Forms.Button();
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
        FirstModeButton.Location = new System.Drawing.Point(121, 216);
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
        SecondModeButton.Location = new System.Drawing.Point(366, 216);
        SecondModeButton.Name = "SecondModeButton";
        SecondModeButton.Size = new System.Drawing.Size(142, 161);
        SecondModeButton.TabIndex = 2;
        SecondModeButton.Text = "Средняя школа\r\n\r\n5-9 год обучения";
        SecondModeButton.UseVisualStyleBackColor = true;
        SecondModeButton.Click += SecondModeButton_Click;
        // 
        // ThirdModeButton
        // 
        ThirdModeButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        ThirdModeButton.Location = new System.Drawing.Point(621, 216);
        ThirdModeButton.Name = "ThirdModeButton";
        ThirdModeButton.Size = new System.Drawing.Size(142, 161);
        ThirdModeButton.TabIndex = 3;
        ThirdModeButton.Text = "Старшая школа\r\n\r\n10-11 год обучения";
        ThirdModeButton.UseVisualStyleBackColor = true;
        ThirdModeButton.Click += ThirdModeButton_Click;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
        ClientSize = new System.Drawing.Size(909, 488);
        Controls.Add(ThirdModeButton);
        Controls.Add(SecondModeButton);
        Controls.Add(FirstModeButton);
        Controls.Add(label1);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        ShowIcon = false;
        Text = "Вселенная информатики";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button FirstModeButton;

    private System.Windows.Forms.Button SecondModeButton;

    private System.Windows.Forms.Button ThirdModeButton;

    private System.Windows.Forms.Label label1;

    #endregion
}