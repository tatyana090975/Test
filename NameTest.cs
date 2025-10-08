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
        //Выход из процесса создания теста и возврат на стартовую форму StartPage
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
        //Сохранение наименования теста в таблицу nametest и переход к процессу создания вопросов и ответов к ним
        private void OK_Click(object sender, EventArgs e)
        {
            //Проверка заполненности наименования
            String nametest = nameTestBox.Text;
            if (nametest == "")
            {
                MessageBox.Show("Заполните наименование!");
                return;
            }
            else
            {                
                DBQueries.CreateTestName(nametest);
                this.Hide();
                CreateQuestion createQuestion = new CreateQuestion();
                createQuestion.Show();
            }                
        }        
    }
}
