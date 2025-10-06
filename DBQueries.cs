using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    internal class DBQueries
    {

        public DataTable LoadLoginList()
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
        //Загрузка для заполнения списка positionList
        public DataTable LoadPositionList()
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
        //Загрузка для заполнения списка divisionList
        public DataTable LoadDivisionList()
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
        public void SaveNewUser(string name, string surname, string secondname, int position, int division, string login, string pass)
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
        public void CreateTestName(string name)
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
        public void SaveQuestion(string question, string ans1, string ans2, string ans3, string ans4, int rb1, int rb2, int rb3, int rb4)
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
        public void DeleteTestName()
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
        public DataTable LoadTests()
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
    }
}
