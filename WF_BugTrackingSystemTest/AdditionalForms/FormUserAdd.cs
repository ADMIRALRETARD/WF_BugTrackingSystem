using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WF_BugTrackingSystemTest
{
    public partial class FormUserAdd : Form
    {
        private Form1 f1;
        public FormUserAdd(Form1 frm)
        {
            InitializeComponent();

            f1 = frm;
            frm.DbConnection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommand = "INSERT INTO USERS(FirstName,LastName) VALUES(@FirstName,@LastName)";
                SQLiteCommand command = f1.db.CreateCommand();
                command.CommandText = addCommand;

                if (tbFirstName.Text !="" && tbLastName.Text!="")
                {

                    command.Parameters.Add("@FirstName", DbType.String).Value = tbFirstName.Text;
                    command.Parameters.Add("@LastName", DbType.String).Value = tbLastName.Text;

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

        private void FormUserAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.ShowDataGrid(Queries.showUsers);
        }
    }
}
