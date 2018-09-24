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
    public partial class FormTaskAdd : Form
    {

        private Form1 f1;
        public FormTaskAdd()
        {
        }

        public FormTaskAdd(Form1 frm)
        {
            InitializeComponent();
            f1 = frm;
            frm.DbConnection();

            string selectProjects = "Select  ID,ProjectName From Projects";
            string selectUsers = "Select ID,LastName from Users";

            LoadData(selectProjects);
            LoadData(selectUsers);
        }
        private void LoadData(string sqlQuery)
        {
            SQLiteDataAdapter adapter1 = new SQLiteDataAdapter(sqlQuery, f1.db);
            DataTable dt = new DataTable();
            adapter1.Fill(dt);

            if (dt.Columns.Contains("ProjectName"))
            {
                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    cbProjects.Items.Add(cells.GetValue(0) + " [ID] , " + cells.GetValue(1));
                }
            }
            else
                foreach (DataRow row in dt.Rows)
                {
                    var cells = row.ItemArray;
                    cbUsers.Items.Add(cells.GetValue(0) + " [ID] , " + cells.GetValue(1));
                }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommand = "INSERT INTO TASKS(ProjectID,Theme,Type,Priority, UserID, Description) " +
                                    "values(@projectID, @theme, @type, @priority, @userID, @description)";

                SQLiteCommand command = f1.db.CreateCommand();
                command.CommandText = addCommand;

                if (tbDescrition.Text != " " && tbPriority.Text != " " && tbTheme.Text != " " && tbType.Text != " "
                    && cbProjects.Text != " " && cbUsers.Text != " ")
                {

                    command.Parameters.Add("@projectID", DbType.Int32).Value = cbProjects.Text.Substring(0, 1);
                    command.Parameters.Add("@theme", DbType.String).Value = tbTheme.Text;
                    command.Parameters.Add("@type", DbType.String).Value = tbType.Text;
                    command.Parameters.Add("@priority", DbType.String).Value = tbPriority.Text;
                    command.Parameters.Add("@userID", DbType.Int32).Value = cbUsers.Text.Substring(0, 1);
                    command.Parameters.Add("@description", DbType.String).Value = tbDescrition.Text;

                    command.ExecuteNonQuery();
                    ActiveForm.Close();
                }
                else
                    MessageBox.Show("Не все поля заполнены!");
            }

            catch (Exception)
            {
            }

        }

        private void FormTaskAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.ShowDataGrid(Queries.showTasks);
        }
    }
}
