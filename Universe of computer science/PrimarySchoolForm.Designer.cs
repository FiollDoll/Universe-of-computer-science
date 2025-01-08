using System.ComponentModel;

namespace Universe_of_computer_science;

partial class PrimarySchoolForm
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
        ButtonReturn = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        groupBox1 = new System.Windows.Forms.GroupBox();
        button4 = new System.Windows.Forms.Button();
        button3 = new System.Windows.Forms.Button();
        button2 = new System.Windows.Forms.Button();
        button1 = new System.Windows.Forms.Button();
        panel1 = new System.Windows.Forms.Panel();
        label5 = new System.Windows.Forms.Label();
        groupBox1.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // ButtonReturn
        // 
        ButtonReturn.Location = new System.Drawing.Point(15, 12);
        ButtonReturn.Name = "ButtonReturn";
        ButtonReturn.Size = new System.Drawing.Size(45, 41);
        ButtonReturn.TabIndex = 0;
        ButtonReturn.Text = "<-";
        ButtonReturn.UseVisualStyleBackColor = true;
        ButtonReturn.Click += ButtonReturn_Click;
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        label1.Location = new System.Drawing.Point(9, 91);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(482, 45);
        label1.TabIndex = 2;
        label1.Text = "Название темы";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // groupBox1
        // 
        groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
        groupBox1.Controls.Add(button4);
        groupBox1.Controls.Add(button3);
        groupBox1.Controls.Add(button2);
        groupBox1.Controls.Add(button1);
        groupBox1.Location = new System.Drawing.Point(103, 139);
        groupBox1.Margin = new System.Windows.Forms.Padding(0);
        groupBox1.Name = "groupBox1";
        groupBox1.Padding = new System.Windows.Forms.Padding(2);
        groupBox1.Size = new System.Drawing.Size(285, 118);
        groupBox1.TabIndex = 3;
        groupBox1.TabStop = false;
        // 
        // button4
        // 
        button4.Anchor = System.Windows.Forms.AnchorStyles.Top;
        button4.Location = new System.Drawing.Point(9, 86);
        button4.Margin = new System.Windows.Forms.Padding(0);
        button4.Name = "button4";
        button4.Size = new System.Drawing.Size(266, 28);
        button4.TabIndex = 3;
        button4.Text = "Название темы";
        button4.UseVisualStyleBackColor = true;
        // 
        // button3
        // 
        button3.Anchor = System.Windows.Forms.AnchorStyles.Top;
        button3.Location = new System.Drawing.Point(9, 58);
        button3.Margin = new System.Windows.Forms.Padding(0);
        button3.Name = "button3";
        button3.Size = new System.Drawing.Size(266, 28);
        button3.TabIndex = 2;
        button3.Text = "Название темы";
        button3.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        button2.Anchor = System.Windows.Forms.AnchorStyles.Top;
        button2.Location = new System.Drawing.Point(9, 30);
        button2.Margin = new System.Windows.Forms.Padding(0);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(266, 28);
        button2.TabIndex = 1;
        button2.Text = "Название темы";
        button2.UseVisualStyleBackColor = true;
        // 
        // button1
        // 
        button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
        button1.Location = new System.Drawing.Point(9, 2);
        button1.Margin = new System.Windows.Forms.Padding(0);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(266, 28);
        button1.TabIndex = 0;
        button1.Text = "Правила поведения в кабинете информатики";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // panel1
        // 
        panel1.AutoScroll = true;
        panel1.Controls.Add(label5);
        panel1.Controls.Add(label1);
        panel1.Controls.Add(groupBox1);
        panel1.Location = new System.Drawing.Point(66, 12);
        panel1.Name = "panel1";
        panel1.Size = new System.Drawing.Size(831, 464);
        panel1.TabIndex = 4;
        // 
        // label5
        // 
        label5.Font = new System.Drawing.Font("Segoe UI Semibold", 36F, ((System.Drawing.FontStyle)(System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)), System.Drawing.GraphicsUnit.Point);
        label5.Location = new System.Drawing.Point(173, 7);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(454, 66);
        label5.TabIndex = 10;
        label5.Text = "1-4 класс";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // PrimarySchoolForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(909, 488);
        Controls.Add(panel1);
        Controls.Add(ButtonReturn);
        Location = new System.Drawing.Point(15, 15);
        MaximizeBox = false;
        ShowIcon = false;
        Text = "Вселенная информатики";
        groupBox1.ResumeLayout(false);
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label label5;

    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Button button4;
    private System.Windows.Forms.Panel panel1;

    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.GroupBox groupBox1;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button ButtonReturn;

    #endregion
}