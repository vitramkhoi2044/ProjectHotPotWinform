using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ProjectHotpot.DTO
{
    public class Employee : DTOValidator
    {
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "Tên không được để trống")]
        [RegularExpression(@"^.*[a-zA-Z]",ErrorMessage = "Tên chỉ chứa ký tự a-z và A-Z")]
        public String EmployeeName { get; set; }
        [Required(ErrorMessage = "Ca làm việc không được để trống")]
        public String Shift { get; set; }
        [Required(ErrorMessage = "Trạng thái làm việc không được để trống")]
        public String EmployeeStatus { get; set; }
        [Required(ErrorMessage = "Chức vụ không được để trống")]
        public String Position { get; set; }
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [RegularExpression(@"^.*[a-z0-9]", ErrorMessage = "Tên đăng nhập chỉ chứa ký tự a-z và 0-9")]
        public String Username { get; set; }
        public String Password { get; set; }
    }
}
