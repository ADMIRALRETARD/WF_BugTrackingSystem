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
        SQLiteConnection db;
        public FormProjectAdd(Form1 frm)
        {
            InitializeComponent();
            f1 = frm;
            db = f1.DbConnection();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string addCommand = "INSERT INTO Projects(ProjectName) VALUES(@projectName)";
            try
            {

                using (db = f1.DbConnection())
                {
                    SQLiteCommand command = db.CreateCommand();
                    command.CommandText = addCommand;
                    if (tbProjectName.Text == "")
                    {
                        MessageBox.Show("Не все поля заполнены!");
                        return;

                    }
                    command.Parameters.Add("@projectName", DbType.String).Value = tbProjectName.Text;
                    command.ExecuteNonQuery();

                    DialogResult = DialogResult.OK;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления проект", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
