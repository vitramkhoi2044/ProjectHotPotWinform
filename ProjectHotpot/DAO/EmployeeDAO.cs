using ProjectHotpot.BUS;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.PeerToPeer;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjectHotpot.DAO
{
    internal class EmployeeDAO
    {
        public EmployeeDAO()
        {
            new SqlDataAccessHelper();
        }
        public List<Employee> SelectAll()
        {
            string query = "Select * From Employees";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<Employee> employees = new List<Employee>();
            if(dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                    employee.EmployeeName = row["EmployeeName"].ToString();
                    employee.Shift = row["Shift"].ToString();
                    employee.EmployeeStatus = row["EmployeeStatus"].ToString();
                    employee.Position = row["Position"].ToString();
                    employee.Username = row["Username"].ToString();
                    employees.Add(employee);
                }
                return employees;
            }
            return null;
        }

        public Employee SelectByUsername(String userName)
        {
            string query = "Select * From Employees Where Username = @userName";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@username", userName);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                Employee employee = new Employee();
                DataRow row = dataTable.Rows[0];
                employee.Username = row["Username"].ToString();
                employee.Password = row["Password"].ToString();
                return employee;
            }
            return null;
        }
        public Employee SelectByID(int EmployeeID)
        {
            string query = "Select * From Employees Where EmployeeID = @EmployeeID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@EmployeeID", EmployeeID);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                Employee employee = new Employee();
                DataRow row = dataTable.Rows[0];
                employee.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                employee.EmployeeName = row["EmployeeName"].ToString();
                employee.Shift = row["Shift"].ToString();
                employee.EmployeeStatus = row["EmployeeStatus"].ToString();
                employee.Position = row["Position"].ToString();
                employee.Username = row["Username"].ToString();
                employee.Password = row["Password"].ToString();
                return employee;
            }
            return null;
        }
        public List<Employee> SelectByKeyword(string keyword)
        {
            string query = "Select * From Employees Where EmployeeName LIKE @Keyword";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@Keyword", keyword);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            List<Employee> employees = new List<Employee>();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Employee employee = new Employee();
                    employee.EmployeeID = int.Parse(row["EmployeeID"].ToString());
                    employee.EmployeeName = row["EmployeeName"].ToString();
                    employee.Shift = row["Shift"].ToString();
                    employee.EmployeeStatus = row["EmployeeStatus"].ToString();
                    employee.Position = row["Position"].ToString();
                    employee.Username = row["Username"].ToString();
                    employees.Add(employee);
                }
                return employees;
            }
            return null;
        }
        public bool Insert(Employee newEmployee)
        {
            string query = "Insert into Employees(EmployeeName,Shift,EmployeeStatus,Position,Username,Password) Values(@EmployeeName,@Shift,@EmployeeStatus,@Position,@Username,@Password)";
            SqlParameter[] sqlParameters = new SqlParameter[6];
            sqlParameters[0] = new SqlParameter("@EmployeeName", newEmployee.EmployeeName);
            sqlParameters[1] = new SqlParameter("@Shift", newEmployee.Shift);
            sqlParameters[2] = new SqlParameter("@EmployeeStatus", newEmployee.EmployeeStatus);
            sqlParameters[3] = new SqlParameter("@Position", newEmployee.Position);
            sqlParameters[4] = new SqlParameter("@Username", newEmployee.Username);
            sqlParameters[5] = new SqlParameter("@Password", newEmployee.Password);
            bool result = SqlDataAccessHelper.ExecuteInsertQuery(query,sqlParameters);
            return result;
        }
        public bool Update(Employee newEmployee)
        {
            string query = "UPDATE Employees SET EmployeeName = @EmployeeName, Shift = @Shift, EmployeeStatus = @EmployeeStatus, Position = @Position WHERE EmployeeID = @EmployeeID";
            SqlParameter[] sqlParameters = new SqlParameter[5];
            sqlParameters[0] = new SqlParameter("@EmployeeName", newEmployee.EmployeeName);
            sqlParameters[1] = new SqlParameter("@Shift", newEmployee.Shift);
            sqlParameters[2] = new SqlParameter("@EmployeeStatus", newEmployee.EmployeeStatus);
            sqlParameters[3] = new SqlParameter("@Position", newEmployee.Position);
            sqlParameters[4] = new SqlParameter("@EmployeeID", newEmployee.EmployeeID);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
        public bool UpdatePasswordByUserName(string userName, string newPassword)
        {
            string query = "UPDATE Employees SET Password = @Password WHERE Username = @Username";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@Password", newPassword);
            sqlParameters[1] = new SqlParameter("@Username", userName);
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
        public bool Delete(int EmployeeID)
        {
            String query = "Delete from Employees where EmployeeID=@EmployeeID";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@EmployeeID", EmployeeID);
            bool result = SqlDataAccessHelper.ExecuteDeleteQuery(query, sqlParameters);
            return result;
        }
    }
}
