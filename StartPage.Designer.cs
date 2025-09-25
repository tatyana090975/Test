namespace Test
{
    partial class StartPage
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
            this.passTest = new System.Windows.Forms.Button();
            this.createTest = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // passTest
            // 
            this.passTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passTest.Location = new System.Drawing.Point(56, 49);
            this.passTest.Name = "passTest";
            this.passTest.Size = new System.Drawing.Size(666, 105);
            this.passTest.TabIndex = 0;
            this.passTest.Text = "Пройти тест";
            this.passTest.UseVisualStyleBackColor = true;
            // 
            // createTest
            // 
            this.createTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.createTest.Location = new System.Drawing.Point(56, 202);
            this.createTest.Name = "createTest";
            this.createTest.Size = new System.Drawing.Size(666, 105);
            this.createTest.TabIndex = 1;
            this.createTest.Text = "Создать тест";
            this.createTest.UseVisualStyleBackColor = true;
            this.createTest.Click += new System.EventHandler(this.createTest_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(656, 368);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(128, 30);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Выйти";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.createTest);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.passTest);
            this.panel1.Location = new System.Drawing.Point(4, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(793, 401);
            this.panel1.TabIndex = 3;
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "StartPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StartPage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button passTest;
        private System.Windows.Forms.Button createTest;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel panel1;
    }
}