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
        public SQLiteConnection db;
        string tablename;

        FormTaskAdd ftAdd;
        FormUserAdd fuAdd;
        FormProjectAdd fpAdd;
        FormSelect fs;
        DeleteVal dv;


        OpenFileDialog _openFileDialog = new OpenFileDialog();

        public string sqlQuery = Queries.showTasks;  // Default display


        public Form1()
        {
            InitializeComponent();
            ftAdd = new FormTaskAdd(this);
            fuAdd = new FormUserAdd(this);
            fpAdd = new FormProjectAdd(this);
            fs = new FormSelect(this);
            dv=new DeleteVal(this);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbConnection();
            ShowDataGrid(sqlQuery);
        }
        public void DbConnection()
        {
            
            //db = new SQLiteConnection("Data Source=C:\\Users" +
            //   "\\Gercules\\Documents\\Visual Studio 2017\\Projects\\" +
            //   "WF_BugTrackingSystemTest\\WF_BugTrackingSystemTest\\bin\\Debug\\BugTrackerDB.db;" +
            //   "Version=3");
            db = new SQLiteConnection("Data Source=BugTrackerDB.db;Version=3");
            db.Open();

        }
        public void ShowDataGrid(string query)
        {
            sqlQuery = query;
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sqlQuery, db);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach (DataTable dt in ds.Tables)
            {
                dataGridView1.DataSource = dt;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (tablename)
            {
                case "Users":
                    fuAdd.ShowDialog();
                    break;
                case "Projects":
                    fpAdd.ShowDialog();
                    break;
                default:
                    ftAdd.ShowDialog();
                    break;

            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            dv.Delete();
          //  Delete();
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
           
            fs.ShowDialog();
        }

        private void UserTasksListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            fs.ShowDialog();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _openFileDialog.Filter = "DataBase Files(*.db;*.sdb;*.sqlite;*.db3;*.s3db;*.sqlite3;*.sl3;)|";
            if (_openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = _openFileDialog.FileName;
            db = new SQLiteConnection("Data Source=" + filename + ";" + "Version=3");
        }
        //2 Вариант
        //private void Delete()
        //{
        //    string deleteCommand = "DELETE FROM " + tablename + " WHERE ID=@id";
        //    SQLiteCommand cmd = db.CreateCommand();
        //    cmd.CommandText = deleteCommand;
        //    cmd.Parameters.Add("@id", DbType.Int32).Value = dataGridView1.CurrentRow.Cells[0].Value;
        //    cmd.ExecuteNonQuery();
        //    ShowDataGrid(sqlQuery);
        //}

    }
}
