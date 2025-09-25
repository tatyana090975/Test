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
    public partial class StartPage : Form
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void createTest_Click(object sender, EventArgs e)
        {
            this.Hide();
            NameTest nameTest = new NameTest();
            nameTest.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            //Диалог с пользователем            
            DialogResult res = MessageBox.Show("Вы действительно хотите выйти?", "", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                Close();
                Application.Exit();
            }            
        }
    }
}
