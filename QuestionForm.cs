using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class QuestionForm : Form
    {
        //Свойство для перехода по количеству вопросов
        //(QuestionForm должна открываться столько раз, сколько вопросов в тесте)
        private static int counter = 0;
        //Свойство для сохранения id вопросов от меньшего к большему (изменяется и позволяет перейти к следубщему вопросу)
        private static int QI {  get; set; }
        
        public QuestionForm(int qi)
        {
            InitializeComponent();

            Load_QuestionForm(qi);
        }
        public void Load_QuestionForm(int qi)
        {
            //Список кортежей для хранения вопроса и ответов к нему
            List<Tuple<int, int, int, string, int, string, int>> tuples = GetQuestionGroup(qi);
            
            if (counter == TestForm.quantityQuestion - 1)
            {
                ButtonsVisibility();
            }

            //Загрузка вопроса
            int questId = qi; //id вопроса
            QI = questId;
            string questText = tuples[0].Item4; //текст вопроса
            label.Text = questText;

            //Загрузка ответов и отметок корректности
            label1.Text = tuples[0].Item6;
            labelCor1.Text = tuples[0].Item7.ToString();

            label2.Text = tuples[1].Item6;
            labelCor2.Text = tuples[1].Item7.ToString();                      

            label3.Text = tuples[2].Item6;
            labelCor3.Text = tuples[2].Item7.ToString();            

            label4.Text = tuples[3].Item6;
            labelCor4.Text = tuples[3].Item7.ToString();            
        }
        public List<Tuple<int, int, int, string, int, string, int>> GetQuestionGroup(int questionId)
        {
            List<Tuple<int, int, int, string, int, string, int>> tuples = TestForm.CurrentTest
                                        .Where(item => item.Item3 == questionId)
                                        .ToList();
            return tuples;
        }


        //Метод для видимости кнопок
        public void ButtonsVisibility()
        {
            // Доступ к кнопкам при условии, что это последний вопрос в тесте
            this.EndTestButton.Visible = true;
            this.OKButton.Visible = false;
        }       

        private void OKButton_Click(object sender, EventArgs e)
        {
            //Проверка заполнена ли радиокнопка            
            bool isSelected = false;

            foreach (var control in RadioButtonsGroupBox.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)control;
                    if (radioButton.Checked) { isSelected = true; break; }
                }
            }
            if (!isSelected) { MessageBox.Show("Отметьте правильный ответ!"); return; }
            
            //Проверка равен ли единице labelCor соответствующего label
            if (RadioButtonsGroupBoxCheced() == "1")
            {
                int c = TestForm.passtestId; 
                DBQueries.PasstestUpdate(c);
                QI = QI + 1;
                counter = counter + 1;
                QuestionForm newForm = new QuestionForm(QI);
                newForm.ShowDialog();
                counter = counter + 1;
                this.Hide();

            }
            else
            {
                QI = QI + 1;
                counter = counter + 1;
                QuestionForm newForm = new QuestionForm(QI);
                newForm.ShowDialog();
                
                this.Close();
            }
        }
        //Прекращение процесса прохождения теста пользователем и удаление данных из таблицы passtest
        private void CloseButton_Click(object sender, EventArgs e)
        {
            //Диалог с пользователем ДА-Нет
            DialogResult res = MessageBox.Show("Вы действительно хотите выйти?", "", MessageBoxButtons.YesNo);
            //Если Да - то удаляем последнюю запись в таблице passtest и переходим на StartPage
            if (res == DialogResult.Yes)
            {
                DBQueries.StopPassTest();
                
                //переходим на StartPage*/
                this.Hide();
                StartPage startPage = new StartPage();
                startPage.Show();
            }
        }
        //Преобразование результатов состояния радиокнопок из bool в text
        public string RadioButtonsGroupBoxCheced()
        {
            string pbNum = "";
            if (radioButton1.Checked) 
            {  
                pbNum = labelCor1.Text;                  
            }
            else if (radioButton2.Checked) 
            {
                pbNum = labelCor2.Text;
            }
            else if (radioButton3.Checked) 
            {
                pbNum = labelCor3.Text; 
            }
            else if (radioButton4.Checked) 
            {
                pbNum = labelCor4.Text; 
            }
            return pbNum;
        }
        //Завершение теста (кнопка видна только последнем вопросе теста)
        private void EndTestButton_Click(object sender, EventArgs e)
        {
            //Проверка заполнена ли радиокнопка            
            bool isSelected = false;

            foreach (var control in RadioButtonsGroupBox.Controls)
            {
                if (control is RadioButton)
                {
                    RadioButton radioButton = (RadioButton)control;
                    if (radioButton.Checked) { isSelected = true; break; }
                }
            }
            if (!isSelected) { MessageBox.Show("Отметьте правильный ответ!"); return; }


            //Проверка равен ли 1 labelCor соответствующего label
            if (RadioButtonsGroupBoxCheced() == "1")
            {
                int c = TestForm.passtestId;
                //Обновление данных в таблице прохождения теста passtest
                DBQueries.PasstestUpdate(c);                    
                UserResaltForm userResaltForm = new UserResaltForm();
                userResaltForm.Show();                    
                this.Hide();
            }
            else
            {
                UserResaltForm userResaltForm = new UserResaltForm();
                userResaltForm.Show();                
                this.Close();
            }               
        }      
    }
}
