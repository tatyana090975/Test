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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace Test
{
    public partial class RegisterForm : Form
    {
        private List<Tuple<int, string>> positionList {  get; set; }
        private List<Tuple<int, string>> divisionList { get; set; }
        public RegisterForm()
        {
            InitializeComponent();            
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {          
            DBQueries dB = new DBQueries();
            positionList = dB.LoadPositionList().AsEnumerable().Select(row => new Tuple<int, string>((int)row[0], row[1].ToString())).ToList();
            positionField.DataSource = positionList;
            positionField.DisplayMember = "Item2";
            positionField.ValueMember = "Item1";
            positionField.SelectedIndex = -1;

            divisionList = dB.LoadDivisionList().AsEnumerable().Select(row => new Tuple<int, string>((int)row[0], row[1].ToString())).ToList();
            divisionField.DataSource = divisionList;
            divisionField.DisplayMember = "Item2";
            divisionField.ValueMember = "Item1";
            divisionField.SelectedIndex = -1;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            String name = nameField.Text;
            String surname = surnameField.Text;
            String secondname = secondNameField.Text;
            String position = positionField.Text;
            String division = divisionField.Text;
            Int32 positionNum = (int)positionField.SelectedValue;
            Int32 divisionNum = (int)divisionField.SelectedValue;
            String login = loginUserField.Text;
            String pass = passwordUserField.Text;
            DBQueries dBQueries = new DBQueries();  
            //Проверка заполненности полей
            if (name == "" || surname == "" || secondname == "" || position == "" || division == "" || login == "" || pass == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            var result = LoginForm.loginPasswordList.Any(t => t.Item2 == login);
            if (result == true)
            {
                MessageBox.Show("Логин занят, придумайте другой логин.");
            }
            else
            {
                DB dB = new DB();
                dBQueries.SaveNewUser(name, surname, secondname, positionNum,divisionNum, login, pass);
                MessageBox.Show("Регистрация прошла успешно!");
                Close();
            }
            //DB dB = new DB();
            /*
            else
            {
                //Сохранение логина и пароля в таблицу users
                MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`users_login`, `users_password`) VALUES (@login,@password)", db.GetConnection());
                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginUserField.Text;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = passwordUserField.Text;

                adapter.SelectCommand = command;
                adapter.Fill(table);
                //Сохранение данных пользователя в таблицу person
                DataTable table1 = new DataTable();

                MySqlDataAdapter adapter1 = new MySqlDataAdapter();

                MySqlCommand command1 = new MySqlCommand("INSERT INTO `person` (`person_name`, `person_surname`, `person_secondname`, `person_position`, `person_division`, `person_login`) VALUES (@name, @surname, @secondname, @position, @division, @login)", db.GetConnection());

                MySqlCommand command2 = new MySqlCommand("SELECT `position_id` FROM `position` WHERE `position_name` = @position", db.GetConnection());
                command2.Parameters.Add("@position", MySqlDbType.VarChar).Value = positionField.Text;
                int posId = (int)command2.ExecuteScalar();

                MySqlCommand command3 = new MySqlCommand("SELECT `division_id` FROM `division` WHERE `division_name` = @division", db.GetConnection());
                command3.Parameters.Add("@division", MySqlDbType.VarChar).Value = divisionField.Text;
                int divId = (int)command3.ExecuteScalar();

                MySqlCommand command4 = new MySqlCommand("SELECT `users_id` FROM `users` WHERE `users_login` = @login", db.GetConnection());
                command4.Parameters.Add("@login", MySqlDbType.VarChar).Value = loginUserField.Text;
                int usId = (int)command4.ExecuteScalar();

                command1.Parameters.Add("@name", MySqlDbType.VarChar).Value = nameField.Text;
                command1.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surnameField.Text;
                command1.Parameters.Add("@secondname", MySqlDbType.VarChar).Value = secondNameField.Text;
                command1.Parameters.AddWithValue("@position", posId);
                command1.Parameters.AddWithValue("@division", divId);
                command1.Parameters.AddWithValue("@login", usId);

                adapter1.SelectCommand = command1;
                adapter1.Fill(table1);

                MessageBox.Show("Регистрация прошла успешно!");
                Close();
            }*/
        }        
    }
}

