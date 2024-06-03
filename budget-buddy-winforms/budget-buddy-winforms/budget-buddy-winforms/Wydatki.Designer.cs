namespace budget_buddy_winforms
{
    partial class Wydatki
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            label2 = new Label();
            button1 = new Button();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            Wybierz = new ListBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(332, 50);
            label2.Name = "label2";
            label2.Size = new Size(135, 25);
            label2.TabIndex = 4;
            label2.Text = "Dodaj wydatek";
            label2.Click += label2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(240, 340);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 5;
            button1.Text = "Gotowe";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(265, 137);
            label1.Name = "label1";
            label1.Size = new Size(93, 19);
            label1.TabIndex = 6;
            label1.Text = "Kwota (0,00):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = SystemColors.InfoText;
            label3.Location = new Point(265, 192);
            label3.Name = "label3";
            label3.Size = new Size(72, 19);
            label3.TabIndex = 7;
            label3.Text = "Kategoria:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.ForeColor = SystemColors.InfoText;
            label4.Location = new Point(265, 247);
            label4.Name = "label4";
            label4.Size = new Size(62, 19);
            label4.TabIndex = 8;
            label4.Text = "Notatka:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Location = new Point(360, 134);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 25);
            textBox1.TabIndex = 9;
            textBox1.Text = "np. 90,00";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 10F);
            textBox3.Location = new Point(360, 247);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(175, 25);
            textBox3.TabIndex = 11;
            // 
            // Wybierz
            // 
            Wybierz.Font = new Font("Segoe UI", 10F);
            Wybierz.ForeColor = SystemColors.GrayText;
            Wybierz.FormattingEnabled = true;
            Wybierz.ItemHeight = 17;
            Wybierz.Location = new Point(360, 192);
            Wybierz.Margin = new Padding(0);
            Wybierz.Name = "Wybierz";
            Wybierz.Size = new Size(175, 21);
            Wybierz.TabIndex = 12;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = SystemColors.Info;
            button2.Location = new Point(410, 340);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(150, 40);
            button2.TabIndex = 13;
            button2.Text = "Anuluj";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Wydatki
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(Wybierz);
            Controls.Add(textBox3);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "Wydatki";
            Text = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox3;
        private ListBox Wybierz;
        private Button button2;
    }
}