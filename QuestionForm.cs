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
        public static DataTable answTable {  get; set; }
        private static int counter = 0;
        private int total = 0;
        public QuestionForm(DataTable table)
        {
            InitializeComponent();
            answTable = table;
            total = answTable.Rows.Count;
            labelCounter.Text = $"Открытие: {counter}";
            DataRow row = answTable.Rows[counter];
            Load_QuestionForm(row);
        }

        public QuestionForm(int count):this(answTable)
        {
            counter = count;
            labelCounter.Text = $"Открытие: {counter}";            
        }

        public void Load_QuestionForm(DataRow dr)
        { 
            if (counter == total - 1)
            {
                ButtonsVisibility();
            }
            //Загрузка вопроса
            int questId = (int)dr[0]; //id вопроса
            string questText = (string)dr[2]; //текст вопроса
            label.Text = questText;

            //Загрузка ответов и отметок корректности
            DB dB = new DB();
            dB.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT answer_1, answer_correct FROM answer WHERE answer_questId = @qa", dB.GetConnection());
            command.Parameters.AddWithValue("@qa", questId);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            DataRow row = table.Rows[0];

            label1.Text = row[0].ToString();
            labelCor1.Text = row[1].ToString();

            row = table.Rows[1];

            label2.Text = row[0].ToString();
            labelCor2.Text = row[1].ToString();

            row = table.Rows[2];

            label3.Text = row[0].ToString();
            labelCor3.Text = row[1].ToString();

            row = table.Rows[3];

            label4.Text = row[0].ToString();
            labelCor4.Text = row[1].ToString();
            dB.closeConnection();            
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
            /*
            //Проверка равен ли единице labelCor соответствующего label
            if (RadioButtonsGroupBoxCheced() == "1")
            {
                //Если "ДА", то добавление 1 в таблицу passtest столбец passtest_corransw
                DB dB = new DB();
                dB.openConnection();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand cmd = new MySqlCommand("SELECT MAX(passtest_id) FROM passtest", dB.GetConnection());
                
                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                DataRow dataRow = dt.Rows[0];
                int passId = (int)dataRow[0];

                DataTable dt2 = new DataTable();

                MySqlDataAdapter adapter2 = new MySqlDataAdapter();

                MySqlCommand cmd1 = new MySqlCommand("UPDATE passtest SET passtest_corransw = passtest_corransw + 1 WHERE passtest_id = @id", dB.GetConnection());
                cmd1.Parameters.AddWithValue("@id", passId);

                adapter2.SelectCommand = cmd1;
                adapter2.Fill(dt2);

                dB.closeConnection();
                
                counter = counter + 1;
                QuestionForm newForm = new QuestionForm(counter);
                newForm.ShowDialog();
                counter = counter + 1;
                this.Close();

            }
            else
            {
                counter = counter + 1;
                QuestionForm newForm = new QuestionForm(counter);
                newForm.ShowDialog();
                
                this.Close();
            }*/
        }
        //Кнопка "Отмена"
        private void CloseButton_Click(object sender, EventArgs e)
        {
            //Диалог с пользователем ДА-Нет
            DialogResult res = MessageBox.Show("Вы действительно хотите выйти?", "", MessageBoxButtons.YesNo);
            //Если Да - то удаляем последнюю запись в таблице passtest и переходим на StartPage
            if (res == DialogResult.Yes)
            {
                DB dB = new DB();
                dB.openConnection();

                DataTable dt = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand cmd = new MySqlCommand("DELETE MAX(passtest_id) FROM passtest ", dB.GetConnection());

                adapter.SelectCommand = cmd;
                adapter.Fill(dt);

                //переходим на StartPage
                this.Hide();
                StartPage startPage = new StartPage();
                startPage.Show();
            }
        }
        //
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

            SaveQuestion();
            /*
            //Проверка равен ли 1 labelCor соответствующего label
            if (RadioButtonsGroupBoxCheced() == "1")
            {
                //Если "ДА", то добавление 1 в таблицу passtest столбец passtest_corransw
                DB dB = new DB();
                dB.openConnection();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand cmd = new MySqlCommand("SELECT MAX(passtest_id) FROM passtest", dB.GetConnection());

                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                DataRow dataRow = dt.Rows[0];
                int passId = (int)dataRow[0];

                DataTable dt2 = new DataTable();

                MySqlDataAdapter adapter2 = new MySqlDataAdapter();

                MySqlCommand cmd1 = new MySqlCommand("UPDATE passtest SET passtest_corransw = passtest_corransw + 1 WHERE passtest_id = @id", dB.GetConnection());
                cmd1.Parameters.AddWithValue("@id", passId);

                adapter2.SelectCommand = cmd1;
                adapter2.Fill(dt2);

                dB.closeConnection();
            }*/
            this.Hide();
            UserResaltForm userResaltForm = new UserResaltForm();
            userResaltForm.Show();
        }
        private void SaveQuestion()
        {
            //Проверка равен ли единице labelCor соответствующего label
            if (RadioButtonsGroupBoxCheced() == "1")
            {
                //Если "ДА", то добавление 1 в таблицу passtest столбец passtest_corransw
                DB dB = new DB();
                dB.openConnection();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand cmd = new MySqlCommand("SELECT MAX(passtest_id) FROM passtest", dB.GetConnection());

                adapter.SelectCommand = cmd;
                adapter.Fill(dt);
                DataRow dataRow = dt.Rows[0];
                int passId = (int)dataRow[0];

                DataTable dt2 = new DataTable();

                MySqlDataAdapter adapter2 = new MySqlDataAdapter();

                MySqlCommand cmd1 = new MySqlCommand("UPDATE passtest SET passtest_corransw = passtest_corransw + 1 WHERE passtest_id = @id", dB.GetConnection());
                cmd1.Parameters.AddWithValue("@id", passId);

                adapter2.SelectCommand = cmd1;
                adapter2.Fill(dt2);

                dB.closeConnection();
            }
            else
            {

            }
        }    
    }
}
