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
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
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
            button1.TabIndex = 6;
            button1.Text = "GOTOWE";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 10F);
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Location = new Point(360, 165);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(175, 25);
            textBox1.TabIndex = 11;
            textBox1.Text = "np. 90,00";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(265, 165);
            label1.Name = "label1";
            label1.Size = new Size(93, 19);
            label1.TabIndex = 10;
            label1.Text = "Kwota (0,00):";
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Segoe UI", 10F);
            textBox3.Location = new Point(360, 226);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(175, 25);
            textBox3.TabIndex = 13;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label4.ForeColor = SystemColors.InfoText;
            label4.Location = new Point(265, 228);
            label4.Name = "label4";
            label4.Size = new Size(62, 19);
            label4.TabIndex = 12;
            label4.Text = "Notatka:";
            // 
            // Przychody
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SkyBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(label2);
            Name = "Przychody";
            Text = "Przychody";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private TextBox textBox3;
        private Label label4;
    }
}