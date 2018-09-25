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
using WF_BugTrackingSystemTest.AdditionalForms;


namespace WF_BugTrackingSystemTest
{
    public partial class Form1 : Form
    {
       
        SQLiteCommand cmd;
        string tablename;
        string flag;
        
        OpenFileDialog _openFileDialog = new OpenFileDialog();

        public string sqlQuery = Queries.showTasks;  // Default display


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowDataGrid(sqlQuery);
        }
        public SQLiteConnection DbConnection()
        {

           //SQLiteConnection db = new SQLiteConnection("Data Source=C:\\Users\\Gercules\\Documents\\tz\\BugTrackerDB.db;Version=3");
            
            SQLiteConnection db = new SQLiteConnection("Data Source=BugTrackerDB.db;Version=3");
            
            cmd = new SQLiteCommand();
            cmd.Connection = db;
            db.Open();
            return db;
        }
        public void ShowDataGrid(string query)
        {
            sqlQuery = query;
            DataSet ds = new DataSet();
            using (var db = DbConnection())
            {
            cmd.CommandText = sqlQuery;

                using (var adapter = new SQLiteDataAdapter(sqlQuery, db))
                {
                    adapter.Fill(ds);
                    foreach (DataTable dt in ds.Tables)
                    {
                        dataGridView1.DataSource = dt;
                    }

                }
                lblCount.Text = "Количество записей : " + dataGridView1.RowCount.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (tablename)
            {
                case "Users":
                    using (var fuAdd = new FormUserAdd(this))
                    {
                        if (fuAdd.ShowDialog() == DialogResult.OK)
                        {
                            ShowDataGrid(sqlQuery);
                        }
                    }

                    break;
                case "Projects":
                    using (var fpAdd = new FormProjectAdd(this))
                    {
                        if (fpAdd.ShowDialog() == DialogResult.OK)
                        {
                            ShowDataGrid(sqlQuery);
                        }
                    }
                    break;
                default:
                    using (var ftAdd = new FormTaskAdd(this))
                    {

                        if (ftAdd.ShowDialog() == DialogResult.OK)
                        {
                            ShowDataGrid(sqlQuery);
                        }
                    }
                    break;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DeleteVal dv = new DeleteVal(this);
            dv.Delete();
            ShowDataGrid(sqlQuery);
        }
        private void cbTables_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (cbTables.Text)
            {
                case "Пользователи":
                    tablename = "Users";
                    sqlQuery = Queries.showUsers;
                    ShowDataGrid(sqlQuery);
                    break;
                case "Проекты":
                    tablename = "Projects";
                    sqlQuery = Queries.showProjects;
                    ShowDataGrid(sqlQuery);
                    break;
                default:
                    tablename = "Tasks";
                    sqlQuery = Queries.showTasks;
                    ShowDataGrid(sqlQuery);
                    break;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }

        private void UserListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDataGrid(Queries.showUsers);
        }

        private void ProjectListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDataGrid(Queries.showProjects);
        }

        private void TasksInProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = "Tasks";
            using(var fs=new FormSelect(this,flag))
            {
                if (fs.ShowDialog() == DialogResult.OK)
                { return; }
            }
        }

        private void UserTasksListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = "";
            using (var fs = new FormSelect(this, flag))
            {
                if (fs.ShowDialog() == DialogResult.OK)
                { return; }
            }   
        }
        
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openFileDialog.Filter = "DataBase Files(*.db;*.sdb;*.sqlite;*.db3;*.s3db;*.sqlite3;*.sl3;)|";
            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = _openFileDialog.FileName;
           var db = new SQLiteConnection("Data Source=" + filename + ";" + "Version=3");
            
        }
       

    }
}
