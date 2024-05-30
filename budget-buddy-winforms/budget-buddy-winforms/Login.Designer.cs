namespace budget_buddy_winforms
{
    partial class Login
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
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.OrangeRed;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(325, 350);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 0;
            button1.Text = "KONTYNUUJ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(309, 118);
            label2.Name = "label2";
            label2.Size = new Size(39, 19);
            label2.TabIndex = 2;
            label2.Text = "Imię:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = SystemColors.InfoText;
            label3.Location = new Point(309, 228);
            label3.Name = "label3";
            label3.Size = new Size(201, 19);
            label3.TabIndex = 3;
            label3.Text = "Aktualny budżet (format 0,00):";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Location = new Point(309, 140);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(201, 25);
            textBox1.TabIndex = 4;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 10F);
            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.Location = new Point(309, 250);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(201, 25);
            textBox2.TabIndex = 5;
            textBox2.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(336, 50);
            label1.Name = "label1";
            label1.Size = new Size(127, 20);
            label1.TabIndex = 1;
            label1.Text = "Podaj swoje dane";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(784, 461);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
    }
}
