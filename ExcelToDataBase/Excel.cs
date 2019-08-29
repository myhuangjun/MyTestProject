using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelToDataBase
{
    /// <summary>
    /// 操作Excel
    /// </summary>
    public class Excel
    {
        public DataSet GetExcelToDataTable(string path)
        {
            var ds = new DataSet();
            var connString = "";
            string strFileType = Path.GetExtension(path).ToLower();
            if (strFileType.Trim() == ".xls")
            {
                connString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";Extended Properties=\"Excel 8.0;HDR=Yes;IMEX=2\"";
            }
            else if (strFileType.Trim() == ".xlsx")
            {
                connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=2\"";
            }
            var query = "SELECT * FROM [Sheet1$]";
            using (var conn = new OleDbConnection(connString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var cmd = new OleDbCommand(query, conn);
                    var da = new OleDbDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
            return ds;
        }
    }
}
