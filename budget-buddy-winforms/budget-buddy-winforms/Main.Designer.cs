namespace budget_buddy_winforms
{
    partial class Main
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
            label1 = new Label();
            label2 = new Label();
            label4 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(347, 30);
            label1.Name = "label1";
            label1.Size = new Size(57, 25);
            label1.TabIndex = 2;
            label1.Text = "Witaj";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(245, 70);
            label2.Name = "label2";
            label2.Size = new Size(256, 25);
            label2.TabIndex = 3;
            label2.Text = "Twój aktualny budżet wynosi:";
            label2.Click += label2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(499, 72);
            label4.Name = "label4";
            label4.Size = new Size(54, 23);
            label4.TabIndex = 5;
            label4.Text = "0,00zł";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(397, 30);
            label3.Name = "label3";
            label3.Size = new Size(55, 25);
            label3.TabIndex = 6;
            label3.Text = "imię!";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(310, 120);
            button1.Name = "button1";
            button1.Size = new Size(191, 45);
            button1.TabIndex = 7;
            button1.Text = "Dodaj wydatek";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Black;
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatStyle = FlatStyle.Popup;
            button2.Font = new Font("Segoe UI", 10F);
            button2.ForeColor = SystemColors.Info;
            button2.Location = new Point(310, 180);
            button2.Name = "button2";
            button2.Size = new Size(191, 45);
            button2.TabIndex = 8;
            button2.Text = "Dodaj przychód";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Black;
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatStyle = FlatStyle.Popup;
            button3.Font = new Font("Segoe UI", 10F);
            button3.ForeColor = SystemColors.Info;
            button3.Location = new Point(310, 240);
            button3.Name = "button3";
            button3.Size = new Size(191, 45);
            button3.TabIndex = 9;
            button3.Text = "Zarządzaj limitami";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatStyle = FlatStyle.Popup;
            button4.Font = new Font("Segoe UI", 10F);
            button4.ForeColor = SystemColors.Info;
            button4.Location = new Point(310, 300);
            button4.Name = "button4";
            button4.Size = new Size(191, 45);
            button4.TabIndex = 10;
            button4.Text = "Wygeneruj raport";
            button4.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Black;
            button5.BackgroundImageLayout = ImageLayout.None;
            button5.FlatStyle = FlatStyle.Popup;
            button5.Font = new Font("Segoe UI", 10F);
            button5.ForeColor = SystemColors.Info;
            button5.Location = new Point(310, 360);
            button5.Name = "button5";
            button5.Size = new Size(191, 45);
            button5.TabIndex = 11;
            button5.Text = "Zakończ program";
            button5.UseVisualStyleBackColor = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Main";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label4;
        private Label label3;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
    }
}