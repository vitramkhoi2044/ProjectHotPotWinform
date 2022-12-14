using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace ProjectHotpot.BUS
{
    internal class EmployeeBUS
    {
        public List<Employee> GetAll()
        {
            List<Employee> employees = new EmployeeDAO().SelectAll();
            if(employees != null)
            {
                return employees;
            }
            return null;
        }
        public bool Login(String userName, String password)
        {
            Employee employee = new EmployeeDAO().SelectByUsername(userName);
            if (employee != null)
            {
                String Password = HelperMethod.Decrypt(employee.Password);
                if (employee.Username.Equals(userName) && Password.Equals(password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool ChangePassword(String userName, String newPassword, String currentPassword)
        {
            Employee employee = new EmployeeDAO().SelectByUsername(userName);
            bool result = false;
            if (employee != null && HelperMethod.Decrypt(employee.Password).Equals(currentPassword))
            {
                newPassword = HelperMethod.Encrypt(newPassword);
                result = new EmployeeDAO().UpdatePasswordByUserName(userName, newPassword);
            }
            return result;
        }
        public bool AddNewEmployee(Employee newEmployee)
        {
            String password = "123456";//Defaul Password
            newEmployee.Password = HelperMethod.Encrypt(password);
            bool result = new EmployeeDAO().Insert(newEmployee);
            return result;
        }

        public Employee GetDetails(int ID)
        {
            Employee employee = new EmployeeDAO().SelectByID(ID);
            return employee;
        }
        public List<Employee> Search(string keyword)
        {
            keyword = '%' + keyword.ToLower() + '%';
            List<Employee> employees = new EmployeeDAO().SelectByKeyword(keyword);
            if (employees != null)
            {
                return employees;
            }
            return null;
        }

        public List<Employee> GetByPosition(string position)
        {
            List<Employee> employees = new EmployeeDAO().SelectByPosition(position);
            if (employees != null)
            {
                return employees;
            }
            return null;
        }

        public bool UpdateEmployee(Employee newEmployee)
        {
            bool result = new EmployeeDAO().Update(newEmployee);
            return result;
        }

        public bool DeleteEmployee(int EmployeeID)
        {
            bool result = new EmployeeDAO().Delete(EmployeeID);
            return result;
        }
    }
}
