using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_BugTrackingSystemTest
{
    public partial class Form1 : Form
    {
        public SQLiteConnection db;
        


        FormTaskAdd ftAdd;

        OpenFileDialog _openFileDialog=new OpenFileDialog();
        public Form1()
        {
            InitializeComponent();
            ftAdd = new FormTaskAdd(this);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbConnection();
            ShowDataGrid();


        }
        public void DbConnection()
        {
            //_openFileDialog.Filter = "DataBase Files(*.db;*.sdb;*.sqlite;*.db3;*.s3db;*.sqlite3;*.sl3;)|";
            //if (_openFileDialog.ShowDialog() == DialogResult.Cancel) 
            //    return;
            //string filename = _openFileDialog.FileName;
            //db = new SQLiteConnection("Data Source="+filename+";"+"Version=3");

            db = new SQLiteConnection("Data Source=C:\\Users" +
               "\\Gercules\\Documents\\Visual Studio 2017\\Projects\\" +
               "WF_BugTrackingSystemTest\\WF_BugTrackingSystemTest\\bin\\Debug\\BugTrackerDB.db;" +
               "Version=3");

            db.Open();

           

        }
        private void ShowDataGrid()
        {
            string selectCommand = "select Projects.ProjectName,Theme,Type,Priority,Users.LastName,Description " +
                                    "from Tasks inner  join Projects on Tasks.ProjectID = Projects.ID " +
                                    "inner join Users on Tasks.UserID = Users.ID";

            //string showUsers = "select * from users";                 ОТОБРАЖЕНИЕ ПОЛЬЗОВАТЕЛЕЙ
            //string showProjects="select *from projects";          //  ОТОБРАЖЕНИЕ ПРОЕКТОВ
            // string showTasks = "select *from Tasks";                // ОТОБРАЖЕНИЕ ЗАДАЧ
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(selectCommand, db);

            DataSet ds = new DataSet();
            adapter.Fill(ds);

            foreach (DataTable dt in ds.Tables)
            {
                dataGridView1.DataSource = dt;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //string addCommand = "INSERT INTO TASKS(ProjectID,Theme,Type,Priority, UserID, Description) values('2', 'Тема22', 'Тип1', 'asdsada', '1', 'qqqwewq')";
            ////string deleteCommand = "DELETE FROM TASKS WHERE Theme='Тема77'";
            //SQLiteCommand cmd = db.CreateCommand();
            //cmd.CommandText = addCommand;
            //// cmd.CommandText = deleteCommand;
            //cmd.ExecuteNonQuery();

            //ShowDataGrid();

            ftAdd.ShowDialog();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            
        }
    }
}
