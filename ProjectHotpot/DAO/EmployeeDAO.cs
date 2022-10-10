using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjectHotpot.DAO
{
    internal class EmployeeDAO
    {
        String strCon = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;

        public Employee SelectByUsername(String userName)
        {
            Employee employee = null;
            SqlConnection con = new SqlConnection(strCon);
            con.Open();
            String strCom = "Select * From Employees Where Username = @userName";
            SqlCommand com = new SqlCommand(strCom, con);
            com.Parameters.Add(new SqlParameter("@userName", userName));
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read())
            {
                employee = new Employee()
                {
                    EmployeeID = (int)dr["EmployeeID"],
                    EmployeeName = (String)dr["EmployeeName"],
                    Shift = (String)dr["Shift"],
                    EmployeeStatus = (String)dr["EmployeeStatus"],
                    Position = (String)dr["Position"],
                    Username = (String)dr["Username"],
                    Password = (String)dr["Password"]
                };
            }
            con.Close();
            return employee;
        }
    }
}
