namespace Test
{
    partial class RegisterForm
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
            this.nameField = new System.Windows.Forms.TextBox();
            this.surnameField = new System.Windows.Forms.TextBox();
            this.secondNameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.loginUserField = new System.Windows.Forms.TextBox();
            this.passwordUserField = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.divisionField = new System.Windows.Forms.ComboBox();
            this.positionField = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(286, 68);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(334, 20);
            this.nameField.TabIndex = 0;
            // 
            // surnameField
            // 
            this.surnameField.Location = new System.Drawing.Point(286, 108);
            this.surnameField.Name = "surnameField";
            this.surnameField.Size = new System.Drawing.Size(334, 20);
            this.surnameField.TabIndex = 1;
            // 
            // secondNameField
            // 
            this.secondNameField.Location = new System.Drawing.Point(286, 147);
            this.secondNameField.Name = "secondNameField";
            this.secondNameField.Size = new System.Drawing.Size(334, 20);
            this.secondNameField.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Имя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Фамилия";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Должность";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Подразделение/Группа";
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(528, 377);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(75, 23);
            this.buttonRegister.TabIndex = 10;
            this.buttonRegister.Text = "ОК";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(645, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // loginUserField
            // 
            this.loginUserField.Location = new System.Drawing.Point(286, 274);
            this.loginUserField.Name = "loginUserField";
            this.loginUserField.Size = new System.Drawing.Size(334, 20);
            this.loginUserField.TabIndex = 12;
            // 
            // passwordUserField
            // 
            this.passwordUserField.Location = new System.Drawing.Point(286, 318);
            this.passwordUserField.Name = "passwordUserField";
            this.passwordUserField.Size = new System.Drawing.Size(334, 20);
            this.passwordUserField.TabIndex = 13;
            this.passwordUserField.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(156, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Логин";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(156, 324);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Пароль";
            // 
            // divisionField
            // 
            this.divisionField.FormattingEnabled = true;
            this.divisionField.Location = new System.Drawing.Point(286, 231);
            this.divisionField.Name = "divisionField";
            this.divisionField.Size = new System.Drawing.Size(334, 21);
            this.divisionField.TabIndex = 16;            
            // 
            // positionField
            // 
            this.positionField.FormattingEnabled = true;
            this.positionField.Location = new System.Drawing.Point(286, 189);
            this.positionField.Name = "positionField";
            this.positionField.Size = new System.Drawing.Size(334, 21);
            this.positionField.TabIndex = 17;            
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.positionField);
            this.Controls.Add(this.divisionField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.passwordUserField);
            this.Controls.Add(this.loginUserField);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.secondNameField);
            this.Controls.Add(this.surnameField);
            this.Controls.Add(this.nameField);
            this.Name = "RegisterForm";
            this.Text = "Окно регистрации";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.TextBox surnameField;
        private System.Windows.Forms.TextBox secondNameField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox loginUserField;
        private System.Windows.Forms.TextBox passwordUserField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox divisionField;
        private System.Windows.Forms.ComboBox positionField;
    }
}