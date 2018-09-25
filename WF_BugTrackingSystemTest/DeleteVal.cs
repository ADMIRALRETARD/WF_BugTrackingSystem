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
        
        public DeleteVal(Form1 form)
        {
            form1 = form;

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
                using (var db = form1.DbConnection())
                {
                    SQLiteCommand cmd = db.CreateCommand();
                    cmd.CommandText = deleteCommand;

                    cmd.Parameters.Add("@id", System.Data.DbType.Int32).Value = form1.dataGridView1.CurrentRow.Cells[0].Value;

                    if (FindTable() == "Users")
                    {
                        if (MessageBox.Show("Вы уверены? При удалении этого пользователя " +
                            "будут удалены все соответстсвующие задачи. " +
                            "Продолжить?", "Удалить", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                cmd.CommandText = "Delete From Tasks Where UserID=@id";
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Данные удалены");
                            }
                        }

                    }
                    else if (FindTable() == "Projects")
                    {

                        if (MessageBox.Show("Вы уверены? При удалении этого проекта " +
                            "будут удалены все соответстсвующие задачи. " +
                            "Продолжить?", "Удалить", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                        {
                            if (cmd.ExecuteNonQuery() > 0)
                            {
                                cmd.CommandText = "Delete From Tasks Where ProjectID=@id";
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Данные удалены");
                            }
                        }
                    }
                    else
                        cmd.ExecuteNonQuery();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}

