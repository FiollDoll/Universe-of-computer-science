using System.ComponentModel;

namespace Universe_of_computer_science;

partial class StartLessonForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
        pictureBox1 = new System.Windows.Forms.PictureBox();
        pictureBox2 = new System.Windows.Forms.PictureBox();
        buttonStart = new System.Windows.Forms.Button();
        buttonReturn = new System.Windows.Forms.Button();
        textDescription = new System.Windows.Forms.RichTextBox();
        ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
        SuspendLayout();
        // 
        // pictureBox1
        // 
        pictureBox1.BackColor = System.Drawing.SystemColors.Info;
        pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        pictureBox1.Location = new System.Drawing.Point(116, 21);
        pictureBox1.Name = "pictureBox1";
        pictureBox1.Size = new System.Drawing.Size(185, 197);
        pictureBox1.TabIndex = 0;
        pictureBox1.TabStop = false;
        // 
        // pictureBox2
        // 
        pictureBox2.BackColor = System.Drawing.SystemColors.Info;
        pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        pictureBox2.Location = new System.Drawing.Point(116, 219);
        pictureBox2.Name = "pictureBox2";
        pictureBox2.Size = new System.Drawing.Size(185, 197);
        pictureBox2.TabIndex = 1;
        pictureBox2.TabStop = false;
        // 
        // buttonStart
        // 
        buttonStart.Location = new System.Drawing.Point(454, 376);
        buttonStart.Name = "buttonStart";
        buttonStart.Size = new System.Drawing.Size(246, 40);
        buttonStart.TabIndex = 3;
        buttonStart.Text = "Начать";
        buttonStart.UseVisualStyleBackColor = true;
        buttonStart.Click += buttonStart_Click;
        // 
        // button1
        // 
        buttonReturn.Location = new System.Drawing.Point(11, 12);
        buttonReturn.Name = "button1";
        buttonReturn.Size = new System.Drawing.Size(48, 41);
        buttonReturn.TabIndex = 4;
        buttonReturn.Text = "<-";
        buttonReturn.UseVisualStyleBackColor = true;
        // 
        // textDescription
        // 
        textDescription.BackColor = System.Drawing.SystemColors.Info;
        textDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
        textDescription.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
        textDescription.Location = new System.Drawing.Point(395, 22);
        textDescription.Name = "textDescription";
        textDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
        textDescription.Size = new System.Drawing.Size(364, 348);
        textDescription.TabIndex = 5;
        textDescription.Text = "Текст";
        // 
        // StartLessonForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(textDescription);
        Controls.Add(buttonReturn);
        Controls.Add(buttonStart);
        Controls.Add(pictureBox2);
        Controls.Add(pictureBox1);
        Text = "StartLessonForm";
        ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
        ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
        ResumeLayout(false);
    }

    private System.Windows.Forms.RichTextBox textDescription;

    private System.Windows.Forms.Button buttonStart;
    private System.Windows.Forms.Button buttonReturn;

    private System.Windows.Forms.PictureBox pictureBox2;

    private System.Windows.Forms.PictureBox pictureBox1;

    #endregion
}