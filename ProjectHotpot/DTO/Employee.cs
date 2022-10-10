using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjectHotpot.DTO
{
    internal class Employee
    {
        public int EmployeeID { get; set; }
        public String EmployeeName { get; set; }
        public String Shift { get; set; }
        public String EmployeeStatus { get; set; }
        public String Position { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }

    }
}
