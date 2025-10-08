using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class CreateQuestion : Form
    {
        //String testName {  get; set; }
        public CreateQuestion()
        {
            InitializeComponent();
        }        
        //Выход из процесса создания теста с удалением уже внесенных в базу данных сведений
        private void canselButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите оказаться от создания теста?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //Каскадное удаление нвзвания теста, созанных вопросов и ответов                
                DBQueries.DeleteTestName();
                //Закрыть окно создания вопроса и открыть стартовую страницу
                this.Hide();
                StartPage startPage = new StartPage();
                startPage.Show();
            }
        }
        //Сохранение в базу данных вопроса и ответов к нему
        private void saveButton_Click(object sender, EventArgs e)
        {    
            //Проверка заполненности всех полей формы
            String question = questionTextBox.Text;
            String ans1 = textBox2.Text;
            String ans2 = textBox3.Text;
            String ans3 = textBox4.Text;
            String ans4 = textBox5.Text;
            int rb1 = radioButton1.Checked ? 1 : 0;
            int rb2 = radioButton2.Checked ? 1 : 0;
            int rb3 = radioButton3.Checked ? 1 : 0;
            int rb4 = radioButton4.Checked ? 1 : 0;

            if (question == "" || ans1 == "" || ans2 == "" || ans3 == "" || ans4 == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            //Проверка указан ли правильный ответ
            bool isSelected = false;

            foreach (var control in CorrectAswGroupBox.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)control;
                    if (radioButton.Checked) { isSelected = true; break; }
                }
            }
            if (!isSelected) { MessageBox.Show("Отметьте правильный ответ!"); return; }
            
            //Сохрание вопроса и ответов к нему в сооветствующие таблицы            
            DBQueries.SaveQuestion(question, ans1, ans2, ans3, ans4, rb1, rb2, rb3, rb4);
               
            //Диалог с пользователем о дальнейших действиях
            DialogResult res = MessageBox.Show("Вопрос успешно загружен.\n Хотите создать следующий вопрос?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                CreateQuestion createQuestion = new CreateQuestion();
                createQuestion.Show();
            }
            else
            {
                MessageBox.Show("Нажмите кнопку \"Завершить создание теста\"");
            }            
        }
        //Сохранение в базу данных последнего вопроса теста и завершение процесса создания теста,
        //переход на стартовую страницу StartPage
        private void completeButton_Click(object sender, EventArgs e)
        {
            //Диалог с пользователем о дальнейших действиях
            DialogResult res = MessageBox.Show("Вы действительно хотите завершить создание теста?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                //Проверка заполненности всех полей формы
                String question = questionTextBox.Text;
                String ans1 = textBox2.Text;
                String ans2 = textBox3.Text;
                String ans3 = textBox4.Text;
                String ans4 = textBox5.Text;
                int rb1 = radioButton1.Checked ? 1 : 0;
                int rb2 = radioButton2.Checked ? 1 : 0;
                int rb3 = radioButton3.Checked ? 1 : 0;
                int rb4 = radioButton4.Checked ? 1 : 0;

                if (question == "" || ans1 == "" || ans2 == "" || ans3 == "" || ans4 == "")
                {
                    MessageBox.Show("Заполните все поля!");
                    return;
                }
                //Проверка указан ли правильный ответ
                bool isSelected = false;

                foreach (var control in CorrectAswGroupBox.Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radioButton = (RadioButton)control;
                        if (radioButton.Checked) { isSelected = true; break; }
                    }
                }
                if (!isSelected) { MessageBox.Show("Отметьте правильный ответ!"); return; }
                
                DBQueries.SaveQuestion(question, ans1, ans2, ans3, ans4, rb1, rb2, rb3, rb4);
                this.Hide();
                StartPage start = new StartPage();
                start.Show();
            }            
        }
    }
}
