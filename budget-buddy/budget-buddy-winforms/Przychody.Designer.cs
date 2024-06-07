namespace budget_buddy_winforms
{
    partial class Przychody
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label2.ForeColor = SystemColors.InfoText;
            label2.Location = new Point(333, 50);
            label2.Name = "label2";
            label2.Size = new Size(141, 25);
            label2.TabIndex = 5;
            label2.Text = "Dodaj przychód";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Location = new Point(360, 186);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 25);
            textBox1.TabIndex = 11;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(265, 186);
            label1.Name = "label1";
            label1.Size = new Size(93, 19);
            label1.TabIndex = 10;
            label1.Text = "Kwota (0,00):";
            // 
            // button1
            // 
            button1.BackColor = Color.Blue;
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.FlatStyle = FlatStyle.Popup;
            button1.Font = new Font("Segoe UI", 10F);
            button1.ForeColor = SystemColors.Info;
            button1.Location = new Point(240, 320);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(150, 40);
            button1.TabIndex = 14;
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
            button2.Location = new Point(410, 320);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(150, 40);
            button2.TabIndex = 15;
            button2.Text = "Anuluj";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Przychody
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "Przychody";
            Text = "Przychody";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
    }
}