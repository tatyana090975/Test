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
using static Mysqlx.Datatypes.Scalar.Types;

namespace Test
{
    public partial class UserResaltForm : Form
    {
        //Свойство для помещения результатов прохождения теста и ФИО пользователя
        public static List<Tuple<string, string, string, int, int>> ResultUs{get; set;}
        public UserResaltForm()
        {
            InitializeComponent();
            Load_UserResaltForm();
        }
        
        public void Load_UserResaltForm()
        {
            //Получаем результаты прохождения теста из базы данных
            int passtestId = TestForm.passtestId;
            DataTable table = DBQueries.GetUserResaltData(passtestId);

            ResultUs = table.AsEnumerable()
                .Select(row => new Tuple<string, string, string, int, int>(
                    row[0].ToString(),
                    row[1].ToString(), 
                    row[2].ToString(),
                    Convert.ToInt32(row[3]),
                    Convert.ToInt32(row[4]))).ToList();

            //Присваиваем результаты запроса соответствующим меткам            
            label3.Text = ResultUs[0].Item4.ToString();
            label5.Text = ResultUs[0].Item5.ToString();

            //Присваиваем результаты запроса соответствующей метке            
            label1.Text = ResultUs[0].Item1.ToString();
            label7.Text = ResultUs[0].Item2.ToString();
            label8.Text = ResultUs[0].Item3.ToString();
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
