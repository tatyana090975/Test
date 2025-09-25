using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class CreateQuestion : Form
    {
        public CreateQuestion()
        {
            InitializeComponent();
        }

        

        private void canselButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите оказаться от создания теста?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                //Каскадное удаление нвзвания теста, созанных вопросов и ответов
                DB db = new DB();
                db.openConnection();

                DataTable dt = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT MAX(`nametest_id`) FROM `nametest`", db.GetConnection());
                int nametestId = (int)command.ExecuteScalar();

                MySqlCommand command1 = new MySqlCommand("DELETE FROM `nametest` WHERE `nametest_id` = @ntId", db.GetConnection());
                command1.Parameters.AddWithValue("@ntId", nametestId);

                adapter.SelectCommand = command1;
                adapter.Fill(dt);
                //Закрыть окно создания вопроса и открыть стартовую страницу
                this.Hide();
                StartPage startPage = new StartPage();
                startPage.Show();
            }

            
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //Проверка заполненности всех полей формы
            String question = questionTextBox.Text;
            String ans1 = textBox2.Text;
            String ans2 = textBox3.Text;
            String ans3 = textBox4.Text;
            String ans4 = textBox5.Text;            

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
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT MAX(`nametest_id`) FROM `nametest`", db.GetConnection());
            int nametestId = (int)command.ExecuteScalar();

            MySqlCommand command1 = new MySqlCommand("INSERT INTO `question` (`question_testId`, `question_text`) VALUE (@qtid, @qtext)", db.GetConnection());
            command1.Parameters.AddWithValue("@qtid", nametestId);
            command1.Parameters.Add("@qtext", MySqlDbType.Text).Value = questionTextBox.Text;

            adapter.SelectCommand = command1;
            adapter.Fill(table);

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command2 = new MySqlCommand("SELECT MAX(`question_id`) FROM `question`", db.GetConnection());
            int questionId = (int)command2.ExecuteScalar();            

            MySqlCommand command3 = new MySqlCommand("INSERT INTO `answer` (`answer_questId`, `answer_1`, `answer_correct`) VALUE (@aqid, @aext, @acorr)", db.GetConnection());
            command3.Parameters.AddWithValue("@aqid", questionId);
            command3.Parameters.Add("@aext", MySqlDbType.Text).Value = textBox2.Text;
            command3.Parameters.AddWithValue("@acorr", radioButton1.Checked ? 1 : 0);

            adapter1.SelectCommand = command3;
            adapter1.Fill(table1);

            DataTable table2 = new DataTable();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            MySqlCommand command4 = new MySqlCommand("INSERT INTO `answer` (`answer_questId`, `answer_1`, `answer_correct`) VALUE (@aqid, @aext, @acorr)", db.GetConnection());
            command4.Parameters.AddWithValue("@aqid", questionId);
            command4.Parameters.Add("@aext", MySqlDbType.Text).Value = textBox3.Text;
            command4.Parameters.AddWithValue("@acorr", radioButton2.Checked ? 1 : 0);

            adapter2.SelectCommand = command4;
            adapter2.Fill(table2);

            DataTable table3 = new DataTable();

            MySqlDataAdapter adapter3 = new MySqlDataAdapter();

            MySqlCommand command5 = new MySqlCommand("INSERT INTO `answer` (`answer_questId`, `answer_1`, `answer_correct`) VALUE (@aqid, @aext, @acorr)", db.GetConnection());
            command5.Parameters.AddWithValue("@aqid", questionId);
            command5.Parameters.Add("@aext", MySqlDbType.Text).Value = textBox4.Text;
            command5.Parameters.AddWithValue("@acorr", radioButton3.Checked ? 1 : 0);

            adapter3.SelectCommand = command5;
            adapter3.Fill(table3);

            DataTable table4 = new DataTable();

            MySqlDataAdapter adapter4 = new MySqlDataAdapter();

            MySqlCommand command6 = new MySqlCommand("INSERT INTO `answer` (`answer_questId`, `answer_1`, `answer_correct`) VALUE (@aqid, @aext, @acorr)", db.GetConnection());
            command6.Parameters.AddWithValue("@aqid", questionId);
            command6.Parameters.Add("@aext", MySqlDbType.Text).Value = textBox5.Text;
            command6.Parameters.AddWithValue("@acorr", radioButton4.Checked ? 1 : 0);

            adapter4.SelectCommand = command6;
            adapter4.Fill(table4);
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

        private void completeButton_Click(object sender, EventArgs e)
        {
            //Диалог с пользователем о дальнейших действиях
            DialogResult res = MessageBox.Show("Вы действительно хотите завершить создание теста?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                StartPage start = new StartPage();
                start.Show();
            }            
        }
    }
}
