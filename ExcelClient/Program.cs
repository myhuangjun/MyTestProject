using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelToDataBase;

namespace ExcelClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = "1.xls";
            var ds=new Excel().GetExcelToDataTable(path);
            if (ds == null || ds.Tables[0].Rows.Count < 1) return;
            var dt = ds.Tables[0];
            var str = "";
            foreach (DataRow row in dt.Rows)
            {
                str += row[0] + "," + row[1] + "," + row[2] + "\n";
            }

            Console.WriteLine(str);
            Console.ReadLine();
        }
    }
}
