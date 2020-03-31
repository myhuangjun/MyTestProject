using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Windows.Forms;
using CYQ.Data;
using CYQ.Data.Table;
using CYQ.Data.Tool;

namespace CYQProject
{
    public partial class Form1 : Form
    {
        public bool Flag = false;
        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var model = new Student
            {
                Id = "4a0",
                Name = "李四a0"
            };
            MessageBox.Show(Add(model).ToString());
        }


        public bool Add<T>(T model, string tableName = "")
        {
            var dd = model.GetType().Name;
            if (string.IsNullOrEmpty(tableName)) tableName = dd;
            var zz = model.GetType().GetProperties();
            foreach (var d in zz)
            {
                var cc = d.PropertyType;
                var mm = d.GetValue(model);
                //if (mm == null)
                //{
                //    return false;
                //}
            }

            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tableName = this.textBox1.Text;
            MDataColumn col = new MDataColumn();
            col.Add("Name", SqlDbType.NVarChar);
            col.Add("Age", SqlDbType.Int);
            var flag = DBTool.CreateTable(tableName, col);
            MessageBox.Show(flag + "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CYQ.Data.AppConfig.Debug.OpenDebugInfo = true;
            using (var action = new MAction("Student"))
            {
                action.Set("Id", "-1");
                action.Update("Id=0");
            }

            MessageBox.Show(this, "1111");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Text = GetPath();
        }

        public class Student
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Sex { get; set; }
            public string Weight { get; set; }
            public List<int> HaHa { get; set; }
        }


        public void Update()
        {
            var conn = "host=127.0.0.1;Port=3306;Database=hiswmsmaterial;uid=root;pwd=1234";
            var i = 0;
            using (var action = new MAction("StockTotal", conn))
            {
                //action.SetExpression("v_count=v_count+10");
                action.Set("v_count", 20);
                action.Update();
            }

            MessageBox.Show(this, "1111");
        }


        public string GetPath()
        {
            string filePre = "file:\\";
            if (IsWeb())
            {
                return AppDomain.CurrentDomain.BaseDirectory;
            }

            Assembly ass = System.Reflection.Assembly.GetExecutingAssembly();
            var path = ass.CodeBase;
            return System.IO.Path.GetDirectoryName(path).Replace(filePre, string.Empty) + "\\";
        }


        public bool IsWeb()
        {
            return HttpContext.Current != null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var conn = "host=192.168.0.232;Port=3306;Database=dicomserver;uid=root;pwd=sdt/1234";
            using (var action = new MAction("binddata", conn))
            {
                var dt = action.Select();
                var m = dt.Select("CheckPart<>'-1'");
                textBox2.Text = m.ToJson(false, false);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Regex re = new Regex(@"(?<=43)◎.{1,20}◎(CZ_.*){0,1}(?=)");
            var value = textBox1.Text;
            var dd = re.Matches(value);
            foreach (Match item in dd)
            {
                textBox2.Text += item.Value + "-----------";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            using (var action = new MAction("Teacher"))
            {
                action.Set("Name", "张三");
                action.Insert(InsertOp.ID);
                textBox2.Text += action.Get<int>("SysNo") + "";
            }
        }
        Task task = null;
        public static CancellationTokenSource cts = new CancellationTokenSource();

        private void button8_Click(object sender, EventArgs e)
        {
            Flag = !Flag;
            button8.Text = Flag ? "停止" : "启动";
            if (Flag) //启动线程
            {
                cts = new CancellationTokenSource();
                task = Task.Run(() =>
                {
                    while (!cts.Token.IsCancellationRequested)
                    {
                        textBox2.Text += "我在运行__";
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                    }
                });
            }
            else
            {
                if (task != null)
                {
                    cts.Cancel();
                }
            }
        }

        /// <summary>
        /// 模拟POST/Get 请求
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            string url = "http://localhost:8084/Service/AjaxClinical.ashx";
            var para = "type=GetClinicalDictList&rows=10&page=1";
            var result = SendRequest(url, para);
            textBox2.Text = result;
        }

        #region 后台模拟浏览器get/post请求
        /// <summary>
        /// 发送请求方式
        /// </summary>
        /// <param name="url">请求Url</param>
        /// <param name="para">请求参数</param>
        /// <param name="method">请求方式GET/POST</param>
        /// <returns></returns>
        public static string SendRequest(string url, string para, PostType method = PostType.POST)
        {
            string strResult = "";
            // GET方式
            if (method == PostType.GET)
            {
                try
                {
                    WebRequest wrq = WebRequest.Create(url + "?" + para);
                    wrq.Method = "GET";
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                    WebResponse wrp = wrq.GetResponse();
                    StreamReader sr = new StreamReader(wrp.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                    strResult = sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
            // POST方式
            if (method == PostType.POST)
            {
                byte[] data = Encoding.UTF8.GetBytes(para);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/56.0.2924.87 Safari/537.36";
                request.ContentLength = data.Length;
                Stream newStream = request.GetRequestStream();
                // Send the data.  
                newStream.Write(data, 0, data.Length);
                newStream.Close();

                // Get response  
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                strResult = reader.ReadToEnd();
            }
            return strResult;
        }
        #endregion


        public enum PostType
        {
            POST, GET
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string conn = "host=127.0.0.1;Port=3306;Database=dicomserver;uid=root;pwd=1234";
            using (var action = new MAction("Collect", conn))
            {
                var dt = action.Select();
                dt.JoinOnName = "CollectType";
                dt = dt.Join("CollectType", "GUID", "Name");
                textBox2.Text = dt.ToJson(true, false);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string conn = "host=127.0.0.1;Port=3306;Database=dicomserver;uid=root;pwd=1234";
            string sql = "select a.*,b.AuditLevel  from basicequipment a left join basicequipmenttype b on" +
                         " a.equipmenttype=b.GUID";
            using (var action = new MAction(sql, conn))
            {
                var dt = action.Select(" 1=1  order by AuditLevel desc");
                textBox2.Text = dt.ToJson(false);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string conn = "host=127.0.0.1;Port=3306;Database=dicomserver;uid=root;pwd=1234";
            Test(conn);
        }

        public void Test(string conn)
        {
            using (var action = new MAction("DictionaryInfo", conn))
            {
                action.BeginTransation();
                action.Set("DeptNum", "1");
                action.Set("DocNum",1);
                action.Set("OrgNum", 1);
                action.Set("Name", "测试");
                action.Set("Level", 1);
                action.Set("State",1);
                var i = action.Insert(InsertOp.ID);
                var id = action.Get<int>("SysNo");
                action.ResetTable("dictionarydetailinfo");
                var dt = action.Data.Table.GetSchema(true);
                for (int j = 0; j < 3; j++)
                {
                    var row = dt.NewRow();
                    row.Set("DictionarySysNo", id);
                    row.Set("Value", j);
                    row.Set("Text", j);
                    dt.Rows.Add(row);
                }
                var flag = dt.AcceptChanges(AcceptOp.Insert);
                action.EndTransation();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Stopwatch sw=new Stopwatch();
            sw.Start();
            var result = 0;
            for (int i = 0; i < 10000; i++)
            {
                result += i;
            }
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            textBox2.Text = "执行10000的叠加结果为:" + result+",执行时间:"+ts;
        }
    }
}
