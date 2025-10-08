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
            positionList = DBQueries.LoadPositionList().AsEnumerable().Select(row => new Tuple<int, string>((int)row[0], row[1].ToString())).ToList();
            positionField.DataSource = positionList;
            positionField.DisplayMember = "Item2";
            positionField.ValueMember = "Item1";
            positionField.SelectedIndex = -1;

            divisionList = DBQueries.LoadDivisionList().AsEnumerable().Select(row => new Tuple<int, string>((int)row[0], row[1].ToString())).ToList();
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
            //Проверка заполненности полей
            if (name == "" || surname == "" || secondname == "" || position == "" || division == "" || login == "" || pass == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            //Проверка нового логина на дубли (в базе данных не должно быть одинаковых логинов пользователей)
            var result = LoginForm.loginPasswordList.Any(t => t.Item2 == login);
            if (result == true)
            {
                MessageBox.Show("Логин занят, придумайте другой логин.");
            }
            else
            {
                //Сохранение данных о регистрации пользователя в таблицы users и person базы данных
                DB dB = new DB();
                DBQueries.SaveNewUser(name, surname, secondname, positionNum,divisionNum, login, pass);
                MessageBox.Show("Регистрация прошла успешно!");
                Close();
            }            
        }        
    }
}

