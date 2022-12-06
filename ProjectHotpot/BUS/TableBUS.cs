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

        public Table GetTableDetail(string name)
        {
            Table table = new TableDAO().SelectByName(name);
            if (table != null)
            {
                return table;
            }
            return null;
        }

        public bool UpdateTable(Table newTable)
        {
         
            bool result = new TableDAO().Update(newTable);
            return result;
        }
    }
}
