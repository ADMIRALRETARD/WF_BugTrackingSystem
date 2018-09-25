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
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string addCommand = "INSERT INTO USERS(FirstName,LastName) VALUES(@FirstName,@LastName)";
                using (var db = f1.DbConnection())
                {
                    SQLiteCommand command = db.CreateCommand();
                    command.CommandText = addCommand;

                    if (tbFirstName.Text == "" && tbLastName.Text == "")
                    {

                        MessageBox.Show("Не все поля заполнены!");
                        return;
                    }

                    command.Parameters.Add("@FirstName", DbType.String).Value = tbFirstName.Text;
                    command.Parameters.Add("@LastName", DbType.String).Value = tbLastName.Text;
                    command.ExecuteNonQuery();
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления пользователя", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        
    }
}
