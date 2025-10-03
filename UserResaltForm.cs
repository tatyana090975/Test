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
    public partial class UserResaltForm : Form
    {
        public UserResaltForm()
        {
            InitializeComponent();
            Load_UserResaltForm();
        }
        
        public void Load_UserResaltForm()
        {
            //Запрашивем данные из таблицы результатов прохождения теста passtest
            DB dB = new DB();
            dB.openConnection();

            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT passtest_user, passtest_corransw, passtest_countquest FROM passtest ORDER BY passtest_id DESC LIMIT 1", dB.GetConnection());
            adapter.SelectCommand = command;
            adapter.Fill(dt);

            //Присваиваем результаты запроса соответствующим меткам
            DataRow row = dt.Rows[0];
            int id = (int)row[0];
            label3.Text = row[1].ToString();
            label5.Text = row[2].ToString();

            //Запрашиваем данные из таблицы Person по ранее полученному passtest_id
            DataTable dt2 = new DataTable();
            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT person_name, person_secondname, person_surname FROM person WHERE person_login = @id", dB.GetConnection());
            command1.Parameters.AddWithValue("@id", id);
            adapter1.SelectCommand = command1;
            adapter1.Fill(dt2);

            //Присваиваем результаты запроса соответствующей метке
            DataRow row2 = dt2.Rows[0];
            label1.Text = row2[0].ToString();
            label7.Text = row2[1].ToString();
            label8.Text = row2[2].ToString();          
        }
        
        private void buttonOK_Click(object sender, EventArgs e)
        {
            //Закрываем текущее окно и переходим на стартовую страницу StartPage
            this.Hide();
            StartPage startPage = new StartPage();
            startPage.Show();            
        }
    }
}
