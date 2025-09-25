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
using System.Xml.Linq;

namespace Test
{
    public partial class NameTest : Form
    {
        public NameTest()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            //Диалог с пользователем
            DialogResult res = MessageBox.Show("Вы действительно хотите отменить создание теста?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                StartPage startPage = new StartPage();
                startPage.Show();
            }
        }

        private void OK_Click(object sender, EventArgs e)
        {
            //Проверка заполненности наименования
            String nametest = nameTestBox.Text;
            if (nametest == "")
            {
                MessageBox.Show("Заполните наименование!");
                return;
            }
            DB db = new DB();
            db.openConnection();
            //Сохранение наименовния теста в таблицу nametest
            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("INSERT INTO `nametest` (`nametest_name`) VALUES (@name)", db.GetConnection());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = nameTestBox.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            this.Hide();
            CreateQuestion createQuestion = new CreateQuestion();
            createQuestion.Show();
        }        
    }
}
