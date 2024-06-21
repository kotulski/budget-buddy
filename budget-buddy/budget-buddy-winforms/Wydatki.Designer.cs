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
            textBox1 = new TextBox();
            Wybierz = new ListBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(379, 67);
            label2.Name = "label2";
            label2.Size = new Size(162, 30);
            label2.TabIndex = 4;
            label2.Text = "Dodaj wydatek";
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(274, 453);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(171, 53);
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
            label1.Location = new Point(303, 228);
            label1.Name = "label1";
            label1.Size = new Size(110, 23);
            label1.TabIndex = 6;
            label1.Text = "Kwota (0,00):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = SystemColors.InfoText;
            label3.Location = new Point(303, 321);
            label3.Name = "label3";
            label3.Size = new Size(87, 23);
            label3.TabIndex = 7;
            label3.Text = "Kategoria:";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Location = new Point(411, 224);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(199, 30);
            textBox1.TabIndex = 9;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // Wybierz
            // 
            Wybierz.Font = new Font("Segoe UI", 10F);
            Wybierz.ForeColor = SystemColors.GrayText;
            Wybierz.FormattingEnabled = true;
            Wybierz.ItemHeight = 23;
            Wybierz.Items.AddRange(new object[] { "Inne", "Żywność", "Mieszkanie", "Transport", "Rozrywka", "Opieka Medyczna", "Chemia", "Edukacja" });
            Wybierz.Location = new Point(411, 321);
            Wybierz.Margin = new Padding(0);
            Wybierz.Name = "Wybierz";
            Wybierz.Size = new Size(199, 27);
            Wybierz.TabIndex = 12;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = SystemColors.Info;
            button2.Location = new Point(469, 453);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(171, 53);
            button2.TabIndex = 13;
            button2.Text = "Anuluj";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Wydatki
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(914, 600);
            Controls.Add(button2);
            Controls.Add(Wybierz);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label2);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Wydatki";
            Text = "Wydatki";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private Label label1;
        private Label label3;
        private TextBox textBox1;
        private ListBox Wybierz;
        private Button button2;
    }
}