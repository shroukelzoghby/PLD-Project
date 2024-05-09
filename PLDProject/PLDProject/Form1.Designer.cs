namespace PLDProject
{
    partial class Form1
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(237, 239, 252);
            textBox1.Font = new Font("Simplified Arabic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(22, 46);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(454, 503);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // listBox1
            // 
            listBox1.BackColor = Color.FromArgb(237, 239, 252);
            listBox1.Font = new Font("Simplified Arabic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox1.ForeColor = Color.MediumSlateBlue;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 26;
            listBox1.Location = new Point(22, 591);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(865, 160);
            listBox1.TabIndex = 1;
            // 
            // listBox2
            // 
            listBox2.BackColor = Color.FromArgb(237, 239, 252);
            listBox2.Font = new Font("Simplified Arabic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            listBox2.ForeColor = Color.MediumSlateBlue;
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 26;
            listBox2.Location = new Point(515, 49);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(372, 498);
            listBox2.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Perpetua", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(22, 9);
            label1.Name = "label1";
            label1.Size = new Size(150, 35);
            label1.TabIndex = 3;
            label1.Text = "The Code :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Perpetua", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(328, 550);
            label2.Name = "label2";
            label2.Size = new Size(226, 39);
            label2.TabIndex = 4;
            label2.Text = "Syntax Error : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Perpetua", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(516, 11);
            label3.Name = "label3";
            label3.Size = new Size(335, 35);
            label3.TabIndex = 5;
            label3.Text = "The lexemes and tokens :";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            BackgroundImage = Properties.Resources._6630841;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(925, 762);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ListBox listBox1;
        private ListBox listBox2;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
