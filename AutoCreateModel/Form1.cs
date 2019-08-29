using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CYQ.Data.Tool;

namespace AutoCreateModel
{
    public partial class Form1 : Form
    {
        private string _conn;
        public Form1()
        {
            InitializeComponent();
            textBox_conn.Text = "host=127.0.0.1;Port=3306;Database=ttttt;uid=root;pwd=1234";
        }

        private void button_test_Click(object sender, EventArgs e)
        {
            var conn = textBox_conn.Text;
            _conn = conn;
            var flag = DBTool.TestConn(_conn);
            var message = flag ? "连接成功" : "链接字符串不正确";
            if (!flag) return;
            MessageBox.Show(message);
            var dics = DBTool.GetTables(_conn);
            if (dics.Count < 1) return;
            foreach (var dic in dics)
                comboBox_tables.Items.Add(dic.Key);
            comboBox_tables.SelectedIndex = 0;
            //var dd= comboBox_tables.SelectedValue;
            //textBox_result.Text = dd.ToString();
        }
        /// <summary>
        /// 生成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_create_Click(object sender, EventArgs e)
        {
            var nameSpace = textBox_nameSpace.Text;
            var tableName = comboBox_tables.Text;
            //var cols = DBTool.GetColumns(tableName, _conn);
            var text = @"
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace " + nameSpace + "{\n";
            text += @"public class " + tableName + "{";
            var cols = DBTool.GetColumns(tableName, _conn);
            foreach (var col in cols)
            {
                var note = col.Description;
                var name = col.ColumnName;
                var cc = GetType(col.SqlType, DalType.MsSql);
                text += String.Format(@"
        /// <summary>
        /// {0}
        /// </summary>
        /// <returns></returns>
        public {1} {2} {{get;set;}}", note, cc, name);
            }
            text += "\n}\n}";
            textBox_result.Text = text;

            if (checkBox_savefile.Checked)
            {
                var path = Directory.GetCurrentDirectory() + "/Model/" + tableName + ".cs";
                var flag = IOHelper.Write(path, text);
                var msg = flag ? "生成成功" : "生成失败";
                MessageBox.Show(msg);
            }

        }

        /// <summary>
        /// 获得数据类型对应的Type
        /// </summary>
        public Type GetType(SqlDbType sqlType, DalType dalType)
        {

            switch (sqlType)
            {
                case SqlDbType.BigInt:
                    return typeof(Int64);
                case SqlDbType.Binary:
                case SqlDbType.Image:
                case SqlDbType.VarBinary:
                    return typeof(byte[]);
                case SqlDbType.Bit:
                    return typeof(Boolean);
                case SqlDbType.Text:
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.VarChar:
                case SqlDbType.Time:
                case SqlDbType.Xml:
                    return typeof(String);
                case SqlDbType.SmallDateTime:
                case SqlDbType.DateTimeOffset:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTime:
                case SqlDbType.Date:
                    return typeof(DateTime);
                case SqlDbType.Timestamp:
                    switch (dalType)
                    {
                        case DalType.MsSql:
                        case DalType.Sybase:
                            return typeof(byte[]);
                        default:
                            return typeof(DateTime);
                    }
                case SqlDbType.Money:
                case SqlDbType.Decimal:
                case SqlDbType.SmallMoney:
                    //case SqlDbType.Udt://这个是顶Numeric类型。
                    return typeof(Decimal);
                case SqlDbType.Float:
                    return typeof(Single);
                case SqlDbType.Int:
                    return typeof(int);
                case SqlDbType.Real:
                    return typeof(double);
                case SqlDbType.TinyInt:
                    return typeof(Byte);
                case SqlDbType.SmallInt:
                    return typeof(Int16);
                case SqlDbType.UniqueIdentifier:
                    return typeof(Guid);
                default:
                    return typeof(object);
            }
        }
        public enum DalType
        {
            /// <summary>
            /// 未知
            /// </summary>
            None,
            /// <summary>
            /// MSSQL[2000/2005/2008/2012/...]
            /// </summary>
            MsSql,
            // Excel,
            Access,
            Oracle,
            MySql,
            SQLite,
            /// <summary>
            /// No Support Now
            /// </summary>
            // FireBird,
            /// <summary>
            /// No Support Now
            /// </summary>
            // PostgreSQL,
            /// <summary>
            /// Txt文本数据库
            /// </summary>
            Txt,
            /// <summary>
            /// Xml数据库
            /// </summary>
            Xml,
            Sybase
        }
    }

}
