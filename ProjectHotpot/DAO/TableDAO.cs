using ProjectHotpot.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Xml.Linq;
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

        public List<Table> SelectAllNOTACTIVE()
        {
            string query = "Select * From Tables where TableStatus = @TableStatus";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TableStatus", "False");
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
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
        public Table SelectByName (string name)
        {
            string query = "Select * From Tables Where TableName = @TableName";
            SqlParameter[] sqlParameters = new SqlParameter[1];
            sqlParameters[0] = new SqlParameter("@TableName", name);
            DataTable dataTable = SqlDataAccessHelper.ExecuteSelectQuery(query, sqlParameters);
            if (dataTable.Rows.Count > 0)
            {
                DataRow row = dataTable.Rows[0];
                Table table = new Table();
                table.TableID = int.Parse(row["TableID"].ToString());
                table.TableName = row["TableName"].ToString();
                table.TableStatus = row["TableStatus"].ToString();
                return table;
            }
            return null;
        }

        public bool Update(Table newTable)
        {
            string query = "UPDATE Tables SET TableStatus = @TableStatus WHERE TableID = @TableID";
            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("@TableStatus", newTable.TableStatus);
            sqlParameters[1] = new SqlParameter("@TableID", newTable.TableID);
           
            bool result = SqlDataAccessHelper.ExecuteUpdateQuery(query, sqlParameters);
            return result;
        }
    }
}
