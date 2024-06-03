namespace budget_buddy_winforms
{
    partial class Limity
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
            Wybierz = new ListBox();
            label3 = new Label();
            Wybierz1 = new ListBox();
            label1 = new Label();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(319, 50);
            label2.Name = "label2";
            label2.Size = new Size(162, 25);
            label2.TabIndex = 7;
            label2.Text = "Zarządzaj limitami";
            label2.Click += label2_Click;
            // 
            // Wybierz
            // 
            Wybierz.Font = new Font("Segoe UI", 10F);
            Wybierz.ForeColor = SystemColors.GrayText;
            Wybierz.FormattingEnabled = true;
            Wybierz.ItemHeight = 17;
            Wybierz.Items.AddRange(new object[] { "Ustaw Limit", "Usuń Limit" });
            Wybierz.Location = new Point(385, 137);
            Wybierz.Margin = new Padding(0);
            Wybierz.Name = "Wybierz";
            Wybierz.Size = new Size(175, 21);
            Wybierz.TabIndex = 14;
            Wybierz.SelectedIndexChanged += Wybierz_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = SystemColors.InfoText;
            label3.Location = new Point(260, 137);
            label3.Name = "label3";
            label3.Size = new Size(118, 19);
            label3.TabIndex = 13;
            label3.Text = "Co chcesz zrobić:";
            // 
            // Wybierz1
            // 
            Wybierz1.Font = new Font("Segoe UI", 10F);
            Wybierz1.ForeColor = SystemColors.GrayText;
            Wybierz1.FormattingEnabled = true;
            Wybierz1.ItemHeight = 17;
            Wybierz1.Items.AddRange(new object[] { "Dzień", "Tydzień", "Miesiąc", "Rok" });
            Wybierz1.Location = new Point(385, 192);
            Wybierz1.Margin = new Padding(0);
            Wybierz1.Name = "Wybierz1";
            Wybierz1.Size = new Size(175, 21);
            Wybierz1.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(260, 192);
            label1.Name = "label1";
            label1.Size = new Size(73, 19);
            label1.TabIndex = 15;
            label1.Text = "Jaki okres:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.ForeColor = SystemColors.InfoText;
            label4.Location = new Point(260, 247);
            label4.Name = "label4";
            label4.Size = new Size(93, 19);
            label4.TabIndex = 17;
            label4.Text = "Kwota (0,00):";
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(240, 330);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 19;
            button1.Text = "Gotowe";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DodgerBlue;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = SystemColors.Info;
            button2.Location = new Point(410, 330);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(150, 40);
            button2.TabIndex = 20;
            button2.Text = "Anuluj";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(385, 243);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 23);
            textBox1.TabIndex = 21;
            // 
            // Limity
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(Wybierz1);
            Controls.Add(label1);
            Controls.Add(Wybierz);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "Limity";
            Text = "Limity";
            Load += Limity_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private ListBox Wybierz;
        private Label label3;
        private ListBox Wybierz1;
        private Label label1;
        private Label label4;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
    }
}