namespace game1
{
    partial class Menu
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
            this.start_button = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.level1 = new System.Windows.Forms.RadioButton();
            this.level2 = new System.Windows.Forms.RadioButton();
            this.level3 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(123, 143);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(287, 62);
            this.start_button.TabIndex = 0;
            this.start_button.Text = "Начать";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(287, 62);
            this.button2.TabIndex = 1;
            this.button2.Text = "Выход";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // level1
            // 
            this.level1.AutoSize = true;
            this.level1.Location = new System.Drawing.Point(20, 19);
            this.level1.Name = "level1";
            this.level1.Size = new System.Drawing.Size(75, 17);
            this.level1.TabIndex = 2;
            this.level1.TabStop = true;
            this.level1.Tag = "1";
            this.level1.Text = "уровень 1";
            this.level1.UseVisualStyleBackColor = true;
            // 
            // level2
            // 
            this.level2.AutoSize = true;
            this.level2.Location = new System.Drawing.Point(20, 42);
            this.level2.Name = "level2";
            this.level2.Size = new System.Drawing.Size(75, 17);
            this.level2.TabIndex = 3;
            this.level2.TabStop = true;
            this.level2.Tag = "2";
            this.level2.Text = "уровень 2";
            this.level2.UseVisualStyleBackColor = true;
            // 
            // level3
            // 
            this.level3.AutoSize = true;
            this.level3.Location = new System.Drawing.Point(20, 65);
            this.level3.Name = "level3";
            this.level3.Size = new System.Drawing.Size(75, 17);
            this.level3.TabIndex = 4;
            this.level3.TabStop = true;
            this.level3.Tag = "3";
            this.level3.Text = "уровень 3";
            this.level3.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.level1);
            this.groupBox1.Controls.Add(this.level3);
            this.groupBox1.Controls.Add(this.level2);
            this.groupBox1.Location = new System.Drawing.Point(456, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "выбор уровня";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(123, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "введите ник";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 450);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.start_button);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Button button2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton level1;
        private System.Windows.Forms.RadioButton level2;
        private System.Windows.Forms.RadioButton level3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
    }
}