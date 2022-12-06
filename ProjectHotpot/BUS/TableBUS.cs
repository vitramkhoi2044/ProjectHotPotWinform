using ProjectHotpot.DAO;
using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectHotpot.BUS
{
    internal class TableBUS
    {
        public List<Table> GetAll()
        {
            List<Table> tables = new TableDAO().SelectAll();
            if (tables != null)
            {
                return tables;
            }
            return null;
        }
    }
}
