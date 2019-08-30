using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CYQ.Data.Table;
using CYQ.Data.Tool;

namespace AutoCreateTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var conn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;
            textConn.Text = conn;
        }

        /// <summary>
        /// 测试数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTest_Click(object sender, EventArgs e)
        {
            var conn = textConn.Text;
            var msg = DBTool.TestConn(conn) ? "连接成功" : "连接失败";
            MessageBox.Show(msg);
        }

        /// <summary>
        /// 生成表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            var dc = new MDataColumn();
            var tableName = textTableName.Text;
            var text = textPrimary.Text;
            var cols = textCols.Text;
            var conn = textConn.Text;
            var list = JsonHelper.ToList<ColumnModel>(cols);
            foreach (ColumnModel t in list)
            {
                var cell = new MCellStruct(t.ColName, t.SqlType);
                if (text.ToLower().Equals(t.ColName.ToLower()))
                    cell.IsPrimaryKey = true;
                cell.Description = t.Description;
                dc.Add(cell);
            }
            var msg= DBTool.CreateTable(tableName, dc,conn)?"生成成功":"生成失败";
            MessageBox.Show(msg);
        }

        /// <summary>
        /// 数据库列 对象
        /// </summary>
        public class ColumnModel
        {
            public string ColName { get; set; }
            public string Type { get; set; }
            public string Description { get; set; }
            /// <summary>
            /// Type 对应的数据库类型
            /// </summary>
            public SqlDbType SqlType
            {
                get
                {
                    switch (Type)
                    {
                        case "1":
                            return SqlDbType.Char;
                        case "2":
                            return SqlDbType.NChar;
                        case "3":
                            return SqlDbType.VarChar;
                        case "4":
                            return SqlDbType.NVarChar;
                        case "5":
                            return SqlDbType.Timestamp;
                        case "6":
                            return SqlDbType.Binary;
                        case "7":
                            return SqlDbType.VarBinary;
                        case "8":
                            return SqlDbType.Image;
                        case "9":
                            return SqlDbType.Bit;
                        case "10":
                            return SqlDbType.TinyInt;
                        case "11":
                            return SqlDbType.Money;
                        case "12":
                            return SqlDbType.SmallMoney;
                        case "13":
                            return SqlDbType.SmallDateTime;
                        case "14":
                            return SqlDbType.DateTime2;
                        case "15":
                            return SqlDbType.DateTimeOffset;
                        case "16":
                            return SqlDbType.DateTime;
                        case "17":
                            return SqlDbType.Time;
                        case "18":
                            return SqlDbType.Date;
                        case "19":
                            return SqlDbType.Decimal;
                        case "20":
                            return SqlDbType.Real;
                        case "21":
                            return SqlDbType.UniqueIdentifier;
                        case "22":
                            return SqlDbType.SmallInt;
                        case "23":
                            return SqlDbType.Int;
                        case "24":
                            return SqlDbType.BigInt;
                        case "25":
                            return SqlDbType.Variant;
                        case "26":
                            return SqlDbType.Float;
                        case "27":
                            return SqlDbType.Xml;
                        case "28":
                            return SqlDbType.NText;
                        case "29":
                            return SqlDbType.Text;
                        default:
                            return SqlDbType.Variant;
                    }
                }
            }
        }

    }
}
