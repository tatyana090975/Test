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
    public partial class TestsList : Form
    {        
        public TestsList()
        {
            InitializeComponent();
            TestListFill();
        }
        private void TestListFill()
        {
            //Заполнение грида данными из базы данных            
            nametestDataGridView.DataSource = DBQueries.LoadTests();           
        }
        //Отмена процесса прохождения теста и возвращение на стартовую страницу StartPage
        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы действительно хотите отменить выбор теста?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.Hide();
                StartPage start = new StartPage();
                start.Show();
            }
        }
        //Старт процесса прохождения выбранного теста
        public void OkButton_Click(object sender, EventArgs e)
        {
            int currenRow = (int)nametestDataGridView.CurrentRow.Cells[0].Value;
            TestForm testForm = new TestForm(currenRow);
            testForm.Show();
        }
    }
}
