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
    public partial class TestForm : Form
    {
        public static int c {  get; set; }
        public TestForm(int b)
        {
            InitializeComponent();
            c = b;
            LoadTestForm(b);
        }
        protected void LoadTestForm(int a)
        {
            int c = a;
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command = new MySqlCommand("SELECT nametest_name FROM nametest WHERE nametest_id = @b", db.GetConnection());
            command.Parameters.AddWithValue("@b", c);

            adapter.SelectCommand = command;
            adapter.Fill(table);

            string res = "";
            if (table.Rows.Count > 0) { res = table.Rows[0]["nametest_name"].ToString(); }
            label1.Text = res;

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM question WHERE question_testId = @c", db.GetConnection());
            command1.Parameters.AddWithValue("@c", c);

            adapter1.SelectCommand = command1;
            adapter1.Fill(dt);
            int count = dt.Rows.Count;

            label3.Text = count.ToString();
            db.closeConnection();
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            db.openConnection();

            DataTable table = new DataTable();
            MySqlDataAdapter adapter2 = new MySqlDataAdapter();

            

            MySqlCommand command2 = new MySqlCommand("SELECT * FROM question WHERE question_testId = @d", db.GetConnection());
            command2.Parameters.AddWithValue("@d", c);

            adapter2.SelectCommand = command2;

            adapter2.Fill(table);

            int count = table.Rows.Count;
        }
    }
}
