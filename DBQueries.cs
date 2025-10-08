using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    internal class DBQueries
    {
        //Загрузка списка пользователей в поле loginPasswordList LoginForm
        public static DataTable LoadLoginList()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT users_id, users_login, users_password FROM users", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dB.closeConnection();
            return table;            
        }
        //Загрузка для заполнения списка positionList RegisterForm
        public static DataTable LoadPositionList()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM position", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dB.closeConnection();
            return table;
        }
        //Загрузка для заполнения списка divisionList RegisterForm
        public static DataTable LoadDivisionList()
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT * FROM division", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dB.closeConnection();
            return table;
        }
        // Сохранение в базу данных нового пользователя в таблицы users и person
        public static void SaveNewUser(string name, string surname, string secondname, int position, int division, string login, string pass)
        {
            DB dB = new DB();
            dB.openConnection();
            //Сохранение логина и пароля в таблицу users
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO users (users_login, users_password) VALUES (@login,@password)", dB.GetConnection());
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = pass;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            //Сохранение данных пользователя в таблицу person
            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command4 = new MySqlCommand("SELECT users_id FROM users WHERE users_login = @login", dB.GetConnection());
            command4.Parameters.Add("@login", MySqlDbType.VarChar).Value = login;
            int usId = (int)command4.ExecuteScalar();

            MySqlCommand command1 = new MySqlCommand("INSERT INTO person (person_name, person_surname, person_secondname, person_position, person_division, person_login) VALUES (@name, @surname, @secondname, @position, @division, @login)", dB.GetConnection());
            command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command1.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
            command1.Parameters.Add("@secondname", MySqlDbType.VarChar).Value = secondname;
            command1.Parameters.Add("@position", MySqlDbType.Int32).Value = position;
            command1.Parameters.Add("@division", MySqlDbType.Int32).Value = division;
            command1.Parameters.AddWithValue("@login", usId);



            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
        }
        //Создание нового наименования теста в таблице nametest
        public static void CreateTestName(string name)
        {
            DB dB = new DB();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();
            MySqlCommand command2 = new MySqlCommand("INSERT INTO nametest(nametest_name) VALUES (@nt)", dB.GetConnection());
            command2.Parameters.Add("@nt", MySqlDbType.VarChar).Value=name;

            adapter2.SelectCommand = command2;
            adapter2.Fill(table);
            dB.closeConnection();
        }
        //Сохранение вопроса и ответов на него в таблицы question и answer
        public static void SaveQuestion(string question, string ans1, string ans2, string ans3, string ans4, int rb1, int rb2, int rb3, int rb4)
        {
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT MAX(nametest_id) FROM nametest", db.GetConnection());
            int nametestId = (int)command.ExecuteScalar();

            MySqlCommand command1 = new MySqlCommand("INSERT INTO question (question_testId, question_text) VALUE (@qtid, @qtext)", db.GetConnection());
            command1.Parameters.AddWithValue("@qtid", nametestId);
            command1.Parameters.Add("@qtext", MySqlDbType.Text).Value = question;

            adapter.SelectCommand = command1;
            adapter.Fill(table);

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            MySqlCommand command2 = new MySqlCommand("SELECT MAX(question_id) FROM question", db.GetConnection());
            int questionId = (int)command2.ExecuteScalar();

            MySqlCommand command3 = new MySqlCommand("INSERT INTO answer (answer_questId, answer_1, answer_correct) VALUE (@aqid, @aext, @acorr)", db.GetConnection());
            command3.Parameters.AddWithValue("@aqid", questionId);
            command3.Parameters.Add("@aext", MySqlDbType.Text).Value = ans1;
            command3.Parameters.Add("@acorr", MySqlDbType.Int32).Value = rb1;

            adapter1.SelectCommand = command3;
            adapter1.Fill(table1);

            DataTable table2 = new DataTable();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            MySqlCommand command4 = new MySqlCommand("INSERT INTO answer (answer_questId, answer_1, answer_correct) VALUE (@aqid, @aext, @acorr)", db.GetConnection());
            command4.Parameters.AddWithValue("@aqid", questionId);
            command4.Parameters.Add("@aext", MySqlDbType.Text).Value = ans2;
            command4.Parameters.Add("@acorr", MySqlDbType.Int32).Value = rb2;

            adapter2.SelectCommand = command4;
            adapter2.Fill(table2);

            DataTable table3 = new DataTable();

            MySqlDataAdapter adapter3 = new MySqlDataAdapter();

            MySqlCommand command5 = new MySqlCommand("INSERT INTO answer (answer_questId, answer_1, answer_correct) VALUE (@aqid, @aext, @acorr)", db.GetConnection());
            command5.Parameters.AddWithValue("@aqid", questionId);
            command5.Parameters.Add("@aext", MySqlDbType.Text).Value = ans3;
            command5.Parameters.Add("@acorr", MySqlDbType.Int32).Value = rb3;

            adapter3.SelectCommand = command5;
            adapter3.Fill(table3);

            DataTable table4 = new DataTable();

            MySqlDataAdapter adapter4 = new MySqlDataAdapter();

            MySqlCommand command6 = new MySqlCommand("INSERT INTO answer (answer_questId, answer_1, answer_correct) VALUE (@aqid, @aext, @acorr)", db.GetConnection());
            command6.Parameters.AddWithValue("@aqid", questionId);
            command6.Parameters.Add("@aext", MySqlDbType.Text).Value = ans4;
            command6.Parameters.Add("@acorr", MySqlDbType.Int32).Value = rb4;

            adapter4.SelectCommand = command6;
            adapter4.Fill(table4);
            db.closeConnection();
        }
        //Каскадное удаление наименования теста, вопросов и ответов к нему при нажатии
        //кнопки "Отмена" в процессе создания очередного вопроса теста
        public static void DeleteTestName()
        {
            DB dB = new DB();
            dB.openConnection();

            DataTable table1 = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT MAX(nametest_id) FROM nametest", dB.GetConnection());
            int nametestId = (int)command.ExecuteScalar();

            MySqlCommand deleteCommand = new MySqlCommand("DELETE FROM nametest WHERE nametest_id = @ni", dB.GetConnection());
            deleteCommand.Parameters.AddWithValue("@ni", nametestId);
            adapter.SelectCommand = deleteCommand;
            adapter.Fill(table1);
            dB.closeConnection();
        }
        //Заполнение данными (списком тестов) грида формы TestsList
        public static DataTable LoadTests()
        {
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM nametest", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);
            db.closeConnection();
            return table;            
        }
        //Загрузка данных (вопросов и ответов к ним) по выбранному тесту в поле CurrentTest формы TestForm
        public static DataTable LoadCurrentTest(int a, int b)
        {
            DB dB = new DB();
            dB.openConnection();
            DataTable table = new DataTable();
            int testId = a;
            int userId = b;
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand(@"
                SELECT 
                    @ui AS user_id,
                    q.question_testId, 
                    q.question_id, 
                    q.question_text, 
                    a.answer_id, 
                    a.answer_1, 
                    a.answer_correct 
                FROM question q 
                INNER JOIN answer a ON q.question_id = a.answer_questId 
                WHERE q.question_testId = @ti", dB.GetConnection());
            command.Parameters.AddWithValue("@ti", testId);
            command.Parameters.AddWithValue("@ui", userId);
            adapter.SelectCommand = command;
            adapter.Fill(table);            

            dB.closeConnection();
            return table;            
        }
        //Создание строки для регистрации результатов прохождения теста в таблице passtets базы данных
        //при загрузке формы TestForm
        public static int AddToPasstest(int usId, int testId, int countQuest)
        {            
            DB db = new DB();
            db.openConnection();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("INSERT INTO passtest(passtest_user, passtest_testId, passtest_corransw, passtest_countquest) VALUES (@ui, @ti, 0, @cq)", db.GetConnection());
            command.Parameters.AddWithValue("@ui", usId);
            command.Parameters.AddWithValue("@ti", testId);
            command.Parameters.AddWithValue("@cq", countQuest);
            adapter.SelectCommand = command;
            adapter.Fill(table);
            DataTable table1 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT MAX(passtest_id) FROM passtest", db.GetConnection());
            adapter1.SelectCommand = command1;
            adapter1.Fill(table1);
            int passtestId = (int)command1.ExecuteScalar();
            db.closeConnection();
            return passtestId;
            
        }
        //Отражение результата (верный или нет ответ) в созданной ранее строке таблицы passtest
        //базы данных при нажатии кнопки "ОК" формы QuestionForm
        public static void PasstestUpdate(int passId)
        {
            DB db = new DB();
            DataTable dt2 = new DataTable();

            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            MySqlCommand cmd1 = new MySqlCommand("UPDATE passtest SET passtest_corransw = passtest_corransw + 1 WHERE passtest_id = @id", db.GetConnection());
            cmd1.Parameters.AddWithValue("@id", passId);

            adapter2.SelectCommand = cmd1;
            adapter2.Fill(dt2);
            db.closeConnection();
        }
        //Прекращение прохождения теста и удаление данных о прохождении из базы данных
        public static void StopPassTest()
        {
            DB dB = new DB();
            dB.openConnection();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM passtest ORDER BY passtest_id DESC LIMIT 1", dB.GetConnection());

            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
        }
        //Запрос результатов прохождения теста пользователем и ФИО пользователя
        public static DataTable GetUserResaltData(int passtestId)
        {
            //Запрашиваем данные из таблицы результатов прохождения теста passtest
            DB dB = new DB();
            dB.openConnection();

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT p.person_name, p.person_secondname, p.person_surname, pt.passtest_corransw, pt.passtest_countquest FROM person p INNER JOIN passtest pt ON p.person_login = pt.passtest_user WHERE pt.passtest_id = @pti", dB.GetConnection());
            command.Parameters.AddWithValue("@pti", passtestId);
            adapter.SelectCommand = command;
            adapter.Fill(dt);
            return dt;            
        }
    }
}
