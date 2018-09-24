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
        string sqltest;
        public FormSelect(Form1 frm)
        {
            InitializeComponent();
            f1 = frm;
            frm.DbConnection();
            
            
            //if (sqltest == "Список задач в проекте")
            //{
             LoadData(Queries.showUsers2);
            //}
            //else
            //    LoadData(Queries.showUsers);
        }
        
        private void LoadData(string sqlQuery)
        {
            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(sqlQuery, f1.db);
            DataTable dt = new DataTable();
            adapter1.Fill(dt);

            //if (dt.Columns.Contains("ProjectName"))
            //{
            //    foreach (DataRow row in dt.Rows)
            //    {
            //        var cells = row.ItemArray;
            //        cbSelect.Items.Add(cells.GetValue(0) + "  [ID] , " + cells.GetValue(1));
            //    }
            //}
            //else
                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    cbSelect.Items.Add(cells.GetValue(0) + "  [ID] , " + cells.GetValue(1));
                }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
          //  string selectCommand = "select Theme from Tasks where ProjectID="+cbSelect.Text.Substring(0,3)+"";
            string selectCommand2 = "select Theme from Tasks where ProjectID=" + cbSelect.Text.Substring(0, 3) + "";

            SQLiteCommand command = f1.db.CreateCommand();
            command.CommandText = selectCommand2;
            
            command.ExecuteScalar();
           
            ActiveForm.Close();
            f1.ShowDataGrid(selectCommand2);
            


        }
    }
}
