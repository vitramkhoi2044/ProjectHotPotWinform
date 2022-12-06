using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.DTO
{
    class Table : DTOValidator
    {
        public int TableID { get; set; }
        [Required(ErrorMessage = "Tên bàn không được để trống")]
        public string TableName { get; set; }

        [Required(ErrorMessage = "Trạng thái không được để trống")]
        public string TableStatus { get; set; }

    }
}
