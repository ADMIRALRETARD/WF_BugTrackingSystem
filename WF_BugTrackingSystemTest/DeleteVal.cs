using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_BugTrackingSystemTest
{
    public class DeleteVal
    {
        Form1 form1;

        SQLiteConnection db;
        public DeleteVal(Form1 form)
        {
            form1 = form;
            db = form.DbConnection();
        }


        private string FindTable()
        {
            switch (form1.cbTables.Text)
            {
                case "Пользователи":
                    return "Users";

                case "Проекты":
                    return "Projects";

                default:
                    return "Tasks";
            }

        }

        public void Delete()
        {
            try
            {

            string deleteCommand = "DELETE FROM " + FindTable() + " WHERE ID=@id";
            using (db=form1.DbConnection())
            {

                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = deleteCommand;

                cmd.Parameters.Add("@id", System.Data.DbType.Int32).Value = form1.dataGridView1.CurrentRow.Cells[0].Value;

                cmd.ExecuteNonQuery();
               
            }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка удаленияй", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

