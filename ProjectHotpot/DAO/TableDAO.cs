using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Table = ProjectHotpot.DTO.Table;

namespace ProjectHotpot.DAO
{
    internal class TableDAO
    {
        public TableDAO()
        {
            new SqlDataAccessHelper();
        }
        public List<Table> SelectAll()
        {
            string query = "Select * From Tables";
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectAllQuery(query);
            List<Table> tables = new List<Table>();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    Table table = new Table();
                    table.TableID = int.Parse(row["TableID"].ToString());
                    table.TableName = row["TableName"].ToString();
                    table.TableStatus = row["TableStatus"].ToString();

                    tables.Add(table);
                }
                return tables;
            }
            return null;
        }
    }
}
