using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    public partial class Dish : DTOValidator
    {
        public int DishID { get; set; }
        [Required(ErrorMessage = "Tên món ăn không được trống")]
        [RegularExpression(@"^.*[a-zA-Z]", ErrorMessage = "Tên món ăn chỉ chứa ký tự a-z và A-Z")]
        public string DishName { get; set; }
        [Required(ErrorMessage = "Giá món ăn không được trống")]
        [RegularExpression(@"^.*[0-9]", ErrorMessage = "Giá món ăn chỉ chứa ký tự 0-9")]
        public int DishPrice { get; set; }
        public byte[] Image { get; set; }
        public int CategoryID { get; set; }
    }
}
