namespace Test
{
    partial class GeneralTestResultForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.TestComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.GroupComboBox = new System.Windows.Forms.ComboBox();
            this.StudentComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.OKBbutton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Group = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResultTest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CloseButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserName,
            this.Group,
            this.ResultTest,
            this.QuantityQuestion});
            this.dataGridView1.Location = new System.Drawing.Point(8, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(787, 181);
            this.dataGridView1.TabIndex = 0;
            // 
            // TestComboBox
            // 
            this.TestComboBox.FormattingEnabled = true;
            this.TestComboBox.Location = new System.Drawing.Point(180, 17);
            this.TestComboBox.Name = "TestComboBox";
            this.TestComboBox.Size = new System.Drawing.Size(317, 21);
            this.TestComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(30, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите тест";
            // 
            // GroupComboBox
            // 
            this.GroupComboBox.FormattingEnabled = true;
            this.GroupComboBox.Location = new System.Drawing.Point(650, 17);
            this.GroupComboBox.Name = "GroupComboBox";
            this.GroupComboBox.Size = new System.Drawing.Size(112, 21);
            this.GroupComboBox.TabIndex = 3;
            this.GroupComboBox.SelectedIndexChanged += new System.EventHandler(this.GroupComboBox_SelectedIndexChanged);
            // 
            // StudentComboBox
            // 
            this.StudentComboBox.FormattingEnabled = true;
            this.StudentComboBox.Location = new System.Drawing.Point(180, 73);
            this.StudentComboBox.Name = "StudentComboBox";
            this.StudentComboBox.Size = new System.Drawing.Size(317, 21);
            this.StudentComboBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(512, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Выберите группу";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(30, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Выберите студента";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.StudentComboBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.TestComboBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.GroupComboBox);
            this.panel1.Location = new System.Drawing.Point(21, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 127);
            this.panel1.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Location = new System.Drawing.Point(12, 173);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(806, 395);
            this.panel2.TabIndex = 8;
            // 
            // OKBbutton
            // 
            this.OKBbutton.Location = new System.Drawing.Point(156, 3);
            this.OKBbutton.Name = "OKBbutton";
            this.OKBbutton.Size = new System.Drawing.Size(98, 23);
            this.OKBbutton.TabIndex = 9;
            this.OKBbutton.Text = "OK";
            this.OKBbutton.UseVisualStyleBackColor = true;
            this.OKBbutton.Click += new System.EventHandler(this.OKBbutton_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.CloseButton);
            this.panel3.Controls.Add(this.OKBbutton);
            this.panel3.Location = new System.Drawing.Point(553, 620);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(266, 34);
            this.panel3.TabIndex = 10;
            // 
            // UserName
            // 
            this.UserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.UserName.HeaderText = "Студент";
            this.UserName.Name = "UserName";
            // 
            // Group
            // 
            this.Group.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Group.HeaderText = "Группа";
            this.Group.Name = "Group";
            // 
            // ResultTest
            // 
            this.ResultTest.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ResultTest.HeaderText = "Кол-во верных ответов";
            this.ResultTest.Name = "ResultTest";
            this.ResultTest.ReadOnly = true;
            // 
            // QuantityQuestion
            // 
            this.QuantityQuestion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuantityQuestion.HeaderText = "Количество вопросов";
            this.QuantityQuestion.Name = "QuantityQuestion";
            this.QuantityQuestion.ReadOnly = true;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(14, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(98, 23);
            this.CloseButton.TabIndex = 10;
            this.CloseButton.Text = "Выход";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // GeneralTestResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 666);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "GeneralTestResultForm";
            this.Text = "GeneralTestResultForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox TestComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox GroupComboBox;
        private System.Windows.Forms.ComboBox StudentComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button OKBbutton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Group;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResultTest;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityQuestion;
        private System.Windows.Forms.Button CloseButton;
    }
}