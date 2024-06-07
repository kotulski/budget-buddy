namespace budget_buddy_winforms
{
    partial class Raport
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
            Wybierz = new ListBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(330, 50);
            label2.Name = "label2";
            label2.Size = new Size(137, 25);
            label2.TabIndex = 6;
            label2.Text = "Generuj raport";
            // 
            // button1
            // 
            button1.BackColor = Color.DodgerBlue;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(325, 350);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 7;
            button1.Text = "Zakończ";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Wybierz
            // 
            Wybierz.Font = new Font("Segoe UI", 10F);
            Wybierz.ForeColor = SystemColors.GrayText;
            Wybierz.FormattingEnabled = true;
            Wybierz.ItemHeight = 17;
            Wybierz.Items.AddRange(new object[] { "Dzień", "Tydzień", "Miesiąc", "Rok" });
            Wybierz.Location = new Point(352, 110);
            Wybierz.Margin = new Padding(0);
            Wybierz.Name = "Wybierz";
            Wybierz.Size = new Size(175, 21);
            Wybierz.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(276, 110);
            label1.Name = "label1";
            label1.Size = new Size(73, 19);
            label1.TabIndex = 17;
            label1.Text = "Jaki okres:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label3.ForeColor = SystemColors.InfoText;
            label3.Location = new Point(125, 170);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 19;
            label3.Text = "WYDATKI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label4.ForeColor = SystemColors.InfoText;
            label4.Location = new Point(579, 170);
            label4.Name = "label4";
            label4.Size = new Size(96, 20);
            label4.TabIndex = 20;
            label4.Text = "PRZYCHODY";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label5.ForeColor = SystemColors.InfoText;
            label5.Location = new Point(61, 195);
            label5.Name = "label5";
            label5.Size = new Size(205, 19);
            label5.TabIndex = 21;
            label5.Text = "(DATA - KWOTA - KATEGORIA)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label6.ForeColor = SystemColors.InfoText;
            label6.Location = new Point(570, 195);
            label6.Name = "label6";
            label6.Size = new Size(116, 19);
            label6.TabIndex = 22;
            label6.Text = "(DATA - KWOTA)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label7.ForeColor = SystemColors.InfoText;
            label7.Location = new Point(109, 300);
            label7.Name = "label7";
            label7.Size = new Size(51, 20);
            label7.TabIndex = 23;
            label7.Text = "Suma:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label8.ForeColor = SystemColors.InfoText;
            label8.Location = new Point(166, 300);
            label8.Name = "label8";
            label8.Size = new Size(52, 20);
            label8.TabIndex = 24;
            label8.Text = "0,00 zł";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label9.ForeColor = SystemColors.InfoText;
            label9.Location = new Point(627, 300);
            label9.Name = "label9";
            label9.Size = new Size(52, 20);
            label9.TabIndex = 26;
            label9.Text = "0,00 zł";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label10.ForeColor = SystemColors.InfoText;
            label10.Location = new Point(570, 300);
            label10.Name = "label10";
            label10.Size = new Size(51, 20);
            label10.TabIndex = 25;
            label10.Text = "Suma:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label11.ForeColor = SystemColors.GrayText;
            label11.Location = new Point(63, 224);
            label11.Name = "label11";
            label11.Size = new Size(87, 20);
            label11.TabIndex = 27;
            label11.Text = "01.01.2024r.";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label12.ForeColor = SystemColors.GrayText;
            label12.Location = new Point(146, 224);
            label12.Name = "label12";
            label12.Size = new Size(15, 20);
            label12.TabIndex = 28;
            label12.Text = "-";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label13.ForeColor = SystemColors.GrayText;
            label13.Location = new Point(160, 224);
            label13.Name = "label13";
            label13.Size = new Size(60, 20);
            label13.TabIndex = 29;
            label13.Text = "90,00 zł";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label14.ForeColor = SystemColors.GrayText;
            label14.Location = new Point(217, 224);
            label14.Name = "label14";
            label14.Size = new Size(15, 20);
            label14.TabIndex = 30;
            label14.Text = "-";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label15.ForeColor = SystemColors.GrayText;
            label15.Location = new Point(226, 224);
            label15.Name = "label15";
            label15.Size = new Size(39, 20);
            label15.TabIndex = 31;
            label15.Text = "Inne";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label22.ForeColor = SystemColors.GrayText;
            label22.Location = new Point(646, 224);
            label22.Name = "label22";
            label22.Size = new Size(60, 20);
            label22.TabIndex = 36;
            label22.Text = "90,00 zł";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label23.ForeColor = SystemColors.GrayText;
            label23.Location = new Point(632, 224);
            label23.Name = "label23";
            label23.Size = new Size(15, 20);
            label23.TabIndex = 35;
            label23.Text = "-";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            label24.ForeColor = SystemColors.GrayText;
            label24.Location = new Point(549, 224);
            label24.Name = "label24";
            label24.Size = new Size(87, 20);
            label24.TabIndex = 34;
            label24.Text = "01.01.2024r.";
            // 
            // Raport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(label22);
            Controls.Add(label23);
            Controls.Add(label24);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Wybierz);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "Raport";
            Text = "Raport";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private ListBox Wybierz;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label22;
        private Label label23;
        private Label label24;
    }
}