using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
        //Свойство для загрузки вопросов к выбранному тесту и ответов к ним
        public static List<Tuple<int, int, int, string, int, string, int>> CurrentTest {  get; set; }
        //
        public static int c {  get; set; }
        //Свойство для сохранения количества вопросов
        public static int quantityQuestion { get; set; }
        //поле для сохранения id новой строки прохождения теста в таблице passtest
        public static int passtestId { get; set; } 
        public TestForm(int b)
        {
            InitializeComponent();
            c = b;
            LoadTestForm(c);
        }
        //Создание списка вопросов и ответов к выбранному тесту и загрузка его в свойство  CurrentTest
        protected void LoadTestForm(int a)
        {
            int userId = LoginForm.userId;
            int testId = a;
            DataTable table = DBQueries.LoadCurrentTest(testId, userId);            
            
            CurrentTest = table.AsEnumerable()
                .Select(row => new Tuple<int, int, int, string, int, string, int>(
                Convert.ToInt32(row[0]),
                Convert.ToInt32(row[1]),
                Convert.ToInt32(row[2]),
                row[3].ToString(),
                Convert.ToInt32(row[4]),
                row[5].ToString(),
                Convert.ToInt32(row[6]))).ToList();

            //Вычисляется количество вопросов в тесте
            quantityQuestion = table.Rows.Count / 4;
            //Открытие формы TestForm
            label3.Text = quantityQuestion.ToString();
            passtestId = DBQueries.AddToPasstest(userId, testId, quantityQuestion);
        }
        //Переход к формированию вопроса теста
        private void ContinueButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var groupedQuestions = CurrentTest
                .GroupBy(item => item.Item3)  // Группируем по id вопроса
                .ToList();

            // Получить список всех уникальных ID вопросов
            List<int> questionIds = groupedQuestions
                .Select(group => group.Key)
                .ToList();

            // Обработка каждой группы
            foreach (int questionId in questionIds)
            {
                QuestionForm questionForm = new QuestionForm(questionId);
                questionForm.Show();
                return;
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
