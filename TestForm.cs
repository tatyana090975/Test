using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class TestForm : Form
    {
        public static int CountQuest {  get; set; }
        public static int c {  get; set; }
        public TestForm(int b)
        {
            InitializeComponent();
            c = b;
            LoadTestForm(b);
        }
        protected void LoadTestForm(int a)
        {            
            //Получение наименования теста из TestsList
            int c = a;
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT nametest_name FROM nametest WHERE nametest_id = @b", db.GetConnection());
            command.Parameters.AddWithValue("@b", c);

            adapter.SelectCommand = command;
            adapter.Fill(table);
            //Получение наименования теста для заголовка формы
            string res = "";
            if (table.Rows.Count > 0) { res = table.Rows[0]["nametest_name"].ToString(); }
            label1.Text = res;
            //Получение списка вопросов для указания количества вопросов в тесте
            DataTable dt = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM question WHERE question_testId = @c", db.GetConnection());
            command1.Parameters.AddWithValue("@c", c);

            adapter1.SelectCommand = command1;
            adapter1.Fill(dt);
            //Вычисляется количество вопросов в тесте
            int count = dt.Rows.Count;
            CountQuest = count;
            //Открытие формы TestForm
            label3.Text = count.ToString();
            db.closeConnection();            
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (LoginForm.Instance != null)
            {
                int userID = LoginForm.Instance.userId;
                //Получения списка вопросов в текущем тесте
                DB db = new DB();
                db.openConnection();

                DataTable table = new DataTable();
                MySqlDataAdapter adapter2 = new MySqlDataAdapter();

                MySqlCommand command2 = new MySqlCommand("SELECT * FROM question WHERE question_testId = @d", db.GetConnection());
                command2.Parameters.AddWithValue("@d", c);

                adapter2.SelectCommand = command2;

                adapter2.Fill(table);

                int count = table.Rows.Count; //количество вопросов в тесте
                //Добавление строки сведений о прохождении теста в таблицу passtest
                DataTable dt1 = new DataTable();
                MySqlDataAdapter adapter1 = new MySqlDataAdapter();

                MySqlCommand command1 = new MySqlCommand("INSERT INTO passtest (passtest_user, passtest_testId, passtest_corransw, passtest_countquest) VALUES (@ui, @ti, @ca, @cq)", db.GetConnection());
                command1.Parameters.AddWithValue("@ui", userID);
                command1.Parameters.AddWithValue("@ti", c);
                command1.Parameters.AddWithValue("@ca", 0);
                command1.Parameters.AddWithValue("@cq", count);

                adapter1.SelectCommand = command1;
                adapter1.Fill(dt1);
                db.closeConnection();

                //стартовать первый вопрос                
                //DataRow dataRow = table.Rows[0];

                if (count > 1)
                {
                    this.Hide();
                    QuestionForm questionForm = new QuestionForm(table);
                    questionForm.Show();
                    return;
                }
                else
                {
                    this.Hide();
                    QuestionForm questionForm = new QuestionForm(table);
                    questionForm.ButtonsVisibility();
                    questionForm.Show();
                    return;
                }
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            //Закрыть окно TestForm и открыть окно списка тестов
            this.Hide();
            TestsList testsList = new TestsList();
            testsList.Show();
        }
    }
}
