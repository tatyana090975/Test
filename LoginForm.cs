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
        //Поле для загрузки данных из базы данных
        internal static List<Tuple<int, string, string>> loginPasswordList { get; set;} 
        //Поле для вычисления текущего пользователя приложения
        public static LoginForm Instance { get; set; }
        //public int userId { get; set; }
        public LoginForm()
        {
            InitializeComponent();

            Load_LoginForm();
        }
        //Загрузка формы (заполнение поля loginPasswordList данными)
        private void Load_LoginForm()
        {
            DBQueries dB = new DBQueries();
            //Загрузка списка логинов и паролей из базы данных
            loginPasswordList = dB.LoadLoginList().AsEnumerable()
                .Select(row =>new Tuple<int, string, string>((int)row[0], row[1].ToString(), row[2].ToString())).ToList();
        }

        //Нажатие ссылки "Зарегистрироваться"
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {  
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            linkLabel1.LinkVisited = true;
        }
        //Вход в приложение
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            //Кнопка "ОК"
            String loginUser = loginField.Text;
            String passUser = passField.Text;
            //Ищем совпадения по логину/паролю
            var result = loginPasswordList.Any(t => t.Item2 == loginUser && t.Item3 == passUser);

            if (result == false)
            {
                MessageBox.Show("Неверный логин или пароль!"); 
            }
            else 
            {
                this.Hide();
                StartPage startPage = new StartPage();
                startPage.Show();
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
