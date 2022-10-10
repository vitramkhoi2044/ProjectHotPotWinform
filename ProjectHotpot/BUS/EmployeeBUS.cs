using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.BUS
{
    internal class EmployeeBUS
    {
        public Employee GetDetails(String userName)
        {
            Employee employee = new EmployeeDAO().SelectByUsername(userName);
            return employee;
        }
    }
}
