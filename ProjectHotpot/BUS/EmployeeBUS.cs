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
        static string key { get; set; } = "ABC123@#789def!!%$465gH";
        public List<Employee> GetAll()
        {
            List<Employee> employees = new EmployeeDAO().SelectAll();
            return employees;
        }
        public bool Login(String userName, String password)
        {
            Employee employee = new EmployeeDAO().SelectByUsername(userName);
            if (employee != null)
            {
                String Password = EmployeeBUS.Decrypt(employee.Password);
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
        public bool AddNewEmployee(Employee newEmployee)
        {
            String password = "123456";//Defaul Password
            newEmployee.Password = EmployeeBUS.Encrypt(password);
            bool result = new EmployeeDAO().Insert(newEmployee);
            return result;
        }

        public static string Encrypt(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }

        public static string Decrypt(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
    }
}
