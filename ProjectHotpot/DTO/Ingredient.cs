using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    class Ingredient : DTOValidator
    {
        public int IngredientID { get; set; }
        [Required(ErrorMessage ="Tên nguyên liệu không được để trống")]
        public string IngredientName { get; set; }
        [Required(ErrorMessage = "Giá nguyên liệu không được để trống")]
        [RegularExpression(@"^.*[0-9]", ErrorMessage = "Giá nguyên liệu chỉ chứa ký tự 0-9")]
        public int IngredientPrice { get; set; }
        [Required(ErrorMessage = "Ngày nhập nguyên liệu không được để trống")]
        public DateTime ImportDate { get; set; }
        [Required(ErrorMessage = "Ngày hết hạn nguyên liệu không được để trống")]
        public DateTime ExpireDate { get; set; }
        [Required(ErrorMessage = "Số lượng nguyên liệu không được để trống")]
        [RegularExpression(@"^.*[0-9]", ErrorMessage = "Số lượng nguyên liệu chỉ chứa ký tự 0-9")]
        public int IngredientQuantity { get; set; }


    }
}
