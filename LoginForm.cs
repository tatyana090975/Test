using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Test
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();            
        }
        //Нажатие ссылки "Зарегистрироваться"
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {  
            RegisterForm form4 = new RegisterForm();
            form4.Show();
            linkLabel1.LinkVisited = true;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            //Кнопка "ОК"
            String loginUser = loginField.Text;
            String passUser = passField.Text;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            //Сравнение введенного логина и пароля с данными в базе (таблица users)
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `users_login` = @lU AND `users_password` = @pU", db.GetConnection());
            command.Parameters.Add("@lU", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@pU", MySqlDbType.VarChar).Value = passUser;
            
            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                this.Hide();
                StartPage startPage = new StartPage();
                startPage.Show();
            }                
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }                
        }
        //Выход со страницы (кнопка "Отмена")
        private void closeWindow_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }
        
    }
}
