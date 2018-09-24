using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_BugTrackingSystemTest
{
    public class DeleteValue
    {
        Form1 form1;
        
        public DeleteValue(Form1 form)
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

        public  void Delete()
        {
            string deleteCommand = "DELETE FROM "+FindTable() +" WHERE ID=@id";
            SQLiteCommand cmd = form1.db.CreateCommand();
            cmd.CommandText = deleteCommand;
            cmd.Parameters.Add("@Table", System.Data.DbType.String).Value = FindTable();
            cmd.Parameters.Add("@id", System.Data.DbType.Int32).Value = form1.dataGridView1.CurrentRow.Cells[0].Value;
          
            cmd.ExecuteNonQuery();
           
        }

    }
}
