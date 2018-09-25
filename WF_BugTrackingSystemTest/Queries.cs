using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_BugTrackingSystemTest
{
    class Queries
    {
       public static string showUsers = "select * from users";
       public static string showUsers2 = "select ID,LastName from users";
       public static string showProjects = "select *from projects";
        public static string showTasks = "select Tasks.ID,Projects.ProjectName,Theme,Type,Priority,Users.LastName,Description " +
                                         "from Tasks inner  join Projects on Tasks.ProjectID = Projects.ID " +
                                         "inner join Users on Tasks.UserID = Users.ID";



    }
}
