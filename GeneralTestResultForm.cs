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
    public partial class GeneralTestResultForm : Form
    { 
        private List<Tuple<int, string>> nametestOll {  get; set; }
        private List<Tuple<int, string>> groupOll { get; set; }
        private List<Tuple<int, string, int, int>> studentOll { get; set; }
        public GeneralTestResultForm()
        {
            InitializeComponent();
            Load_GeneralResultForm();
        }

        public void Load_GeneralResultForm()
        {   
            DB dB = new DB();
            dB.openConnection();

            //Заполнение nametestOll
            DataTable dt = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand commandNameTest = new MySqlCommand("SELECT nametest_id, nametest_name FROM nametest", dB.GetConnection());
            adapter.SelectCommand = commandNameTest;
            adapter.Fill(dt);

            nametestOll = new List<Tuple<int, string>>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                nametestOll.Add(Tuple.Create((int)row[0], row[1].ToString()));
            }
            
            //Заполнение groupOll

            MySqlCommand commandGroup = new MySqlCommand("SELECT division_id, division_name FROM division", dB.GetConnection());

            MySqlDataReader readerGroup = commandGroup.ExecuteReader();
            
            groupOll = new List<Tuple<int, string>>();

            while (readerGroup.Read())
            {
                groupOll.Add(Tuple.Create(readerGroup.GetInt32("division_id"), readerGroup.GetString("division_name")));
            }
            readerGroup.Close();

            //Отключаем обработчик изменения данных
            GroupComboBox.SelectedIndexChanged -= GroupComboBox_SelectedIndexChanged;

            //Заполнение studentOll

            MySqlCommand commandStudent = new MySqlCommand("SELECT person_id, person_name, person_secondname, person_surname, person_division, person_login FROM person", dB.GetConnection());

            MySqlDataReader readerStudent = commandStudent.ExecuteReader();
            studentOll = new List<Tuple<int, string, int, int>>();

            while (readerStudent.Read())
            {
                string item = readerStudent.GetString(1);
                item += " " + readerStudent.GetString(2);
                item += " " + readerStudent.GetString(3);
                studentOll.Add(Tuple.Create(readerStudent.GetInt32("person_id"),item, readerStudent.GetInt32("person_division"), readerStudent.GetInt32("person_login")));
            }
            dB.closeConnection();

            //Заполнение TestComboBox
            TestComboBox.DataSource = new BindingSource(nametestOll, null);
            TestComboBox.DisplayMember = "Item2";
            TestComboBox.ValueMember = "Item1";
            TestComboBox.SelectedIndex = -1;
            
            //Заполнение GroupComboBox
            //Отключаем обработчик изменения данных
            GroupComboBox.SelectedIndexChanged -= GroupComboBox_SelectedIndexChanged;

            GroupComboBox.DataSource = new BindingSource(groupOll, null);
            GroupComboBox.DisplayMember = "Item2";
            GroupComboBox.ValueMember = "Item1";
            GroupComboBox.SelectedIndex = -1;

            GroupComboBox.SelectedIndexChanged += GroupComboBox_SelectedIndexChanged;

            //Заполнение StudentComboBox
            StudentComboBox.DataSource = new BindingSource(studentOll, null);
            StudentComboBox.DisplayMember = "Item2";
            StudentComboBox.ValueMember = "Item1";
            StudentComboBox.SelectedIndex = -1;

            //Заполнение столбцов DataGridView данными

            //Включаем обработчик изменения данных
            
        }

        public void GroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //При изменении значения поля GroupComboBox в поле StudentComboBox должны быть доступны только 
            //те студенты, которые учатся в указанной в GroupComboBox группе
            //Проверяем, что GroupComboBox заполнен значением
            if (GroupComboBox.SelectedItem == null || GroupComboBox.SelectedIndex == -1)
                return;

            //Получаем выбранный элемент
            var selectedItem = GroupComboBox.SelectedItem;

            //находим id выбранной группы и заплдняем StudentComboBox значениями, отобранными по группе
            if (selectedItem is Tuple<int, string> selectedGroup)
            {
                int groupId = selectedGroup.Item1;
                //фильтруем м сортируем студентов по выбранной группе StudentComboBox
                var filteredStudents = studentOll
                    .Where(student => student.Item3 == groupId)
                    .OrderBy(student => student.Item2)
                    .ToList();

                StudentComboBox.DataSource = new BindingSource(filteredStudents, null);
                StudentComboBox.DisplayMember = "Item2";
                StudentComboBox.ValueMember = "Item1";
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartPage startPage = new StartPage();
            startPage.Show();
        }

        private void OKBbutton_Click(object sender, EventArgs e)
        {
            //Проверка на заполненность TestComboBox
            if (TestComboBox.SelectedIndex == -1 || GroupComboBox.SelectedIndex == -1 || StudentComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Заполните все значения отбора");
                return;
            }

            //Получение id пользователя, привязанного к выбранному студенту и id теста
            int testId = 0;
            var selectedTest = TestComboBox.SelectedItem;
            if (selectedTest is Tuple<int, string> selectedTestGroup) { testId = selectedTestGroup.Item1; }
            int userId = 0;
            var selectedStudent = StudentComboBox.SelectedItem;
            if (selectedStudent is Tuple<int, string, int, int> selectedStudentGroup) { userId = selectedStudentGroup.Item4; }
            
            //Получение данных из бд
            DB dB = new DB();
            dB.openConnection();

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand cmd = new MySqlCommand("SELECT passtest_corransw, passtest_countquest FROM passtest WHERE passtest_user = @ui AND passtest_testId = @ti",dB.GetConnection());
            cmd.Parameters.AddWithValue("@ui", userId);
            cmd.Parameters.AddWithValue("@ti", testId);
            adapter.SelectCommand = cmd;
            adapter.Fill(dt);
            dB.closeConnection();

            //Заполнение DataGridView данными
            AddComboBoxValiesToDataGridView(dt);
        }
        private void AddComboBoxValiesToDataGridView(DataTable dt)
        {
            dataGridView1.Rows.Clear();
            int count = dt.Rows.Count;
            
            for (int i = 0; i < count; i++)
            {
                int rowIndex = dataGridView1.Rows.Add();
                //Заполняем первые два столбца
                dataGridView1.Rows[rowIndex].Cells["UserName"].Value = StudentComboBox.Text;
                dataGridView1.Rows[rowIndex].Cells["Group"].Value = GroupComboBox.Text;
                DataRow row1 = dt.Rows[i];
                                
                // Заполняем два следующих столбца
                dataGridView1.Rows[rowIndex].Cells["ResultTest"].Value = row1[0]; // Первый столбец DataTable
                dataGridView1.Rows[rowIndex].Cells["QuantityQuestion"].Value = row1[1]; // Второй столбец DataTable
                
            }
            
        }
    }
}
