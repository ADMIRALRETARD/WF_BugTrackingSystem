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

namespace WF_BugTrackingSystemTest.AdditionalForms
{
    public partial class FormSelect : Form
    {
        private Form1 f1;
        string getflag;
        SQLiteConnection db;
        public FormSelect(Form1 frm, string flag)
        {
            InitializeComponent();
            f1 = frm;
            db = frm.DbConnection();
            getflag = flag;

            if (getflag == "Tasks")
            {
                selector = "Task";
                LoadData(Queries.showProjects);
            }
            else
            {
                selector = "User";
                LoadData(Queries.showUsers2);
            }
        }

        private void LoadData(string sqlQuery)
        {
            using (var adapter = new SQLiteDataAdapter(sqlQuery, db))
            {

                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Columns.Contains("ProjectName"))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        cbSelect.Items.Add(cells.GetValue(0) + "  [ID] , " + cells.GetValue(1));
                    }
                }
                else
                    foreach (DataRow row in dt.Rows)
                    {
                        var cells = row.ItemArray;
                        cbSelect.Items.Add(cells.GetValue(0) + "  [ID] , " + cells.GetValue(1));
                    }
            }
        }
        public  string selector;
        private void btnSelect_Click(object sender, EventArgs e)
        {
            string selectCommand;
            string Command1 = "select Theme from Tasks where ProjectID=" + cbSelect.Text.Substring(0, 3) + "";
            string Command2 = "select Theme from Tasks where UserID=" + cbSelect.Text.Substring(0, 3) + "";
           
            if (selector == "Task")
            {
                selectCommand = Command1;

            }
            else
                selectCommand = Command2;
            using (db = f1.DbConnection())
            {
                SQLiteCommand command = db.CreateCommand();
                command.CommandText = selectCommand;

                command.ExecuteScalar();
                DialogResult = DialogResult.OK;
                f1.ShowDataGrid(selectCommand);
            }
            

        }
    }
}
