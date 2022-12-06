using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    internal class Customer : DTOValidator
    {
        public int CustomerID { get; set; }
        [Required(ErrorMessage ="Tên khách hàng không được để trống")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage = "Điểm số khách hàng không được để trống")]
        [RegularExpression(@"^.*[0-9]", ErrorMessage = "Điểm số khách hàng chỉ chứa ký tự 0-9")]
        public int Score { get; set; }
    }
}
