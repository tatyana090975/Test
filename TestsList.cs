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
        private DataTable TestListFill()
        {
            //Заполнение грида данными из базы данных
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM nametest", db.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);                       

            nametestDataGridView.DataSource = table;
            
            return table;
        }

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
    }
}
