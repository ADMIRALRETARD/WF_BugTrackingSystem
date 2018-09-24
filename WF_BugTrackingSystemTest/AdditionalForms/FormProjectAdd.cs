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
    public partial class FormProjectAdd : Form
    {
        private Form1 f1;
        public FormProjectAdd(Form1 frm)
        {
            InitializeComponent();
            f1 = frm;
            frm.DbConnection();
        }

        private void FormProjectAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.ShowDataGrid(Queries.showProjects);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string addCommand = "INSERT INTO Projects(ProjectName) VALUES(@projectName)";
            SQLiteCommand command = f1.db.CreateCommand();
            command.CommandText = addCommand;

            if (tbProjectName.Text != "")
            {
                command.Parameters.Add("@projectName", DbType.String).Value = tbProjectName.Text;
                command.ExecuteNonQuery();
                ActiveForm.Close();

            }
            else
                MessageBox.Show("Не все поля заполнены!");


        }
    }
}
