using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
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
        public Form1()
        {
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
            string name = "";
            IsEnoughCount(Guid.Empty, out name);
        }


        public void IsEnoughCount(Guid businessId, out string name)
        {
            name = "";
            string sql1 = @"SELECT sout.`Count` as Total,detail.`Count` as V_Count,his.MedicineName as `Name` 
            from DepartmentHousestockout sout  left join DepartmentHouseStockDetail detail on 
            sout.MedicineID=detail.MedicineID and sout.BathCount=detail.BathCount  
            and sout.DepartmentHouseId=detail.DepartmentHouseId left join historydetail his 
            on sout.HistoryId=his.GUID 
            where sout.BusinessID='39f0bb36-9dd6-9a47-1e39-8b57fb254e3e'";
            using (var action = new MAction(sql1))
            {
                var dd = action.Select();
                foreach (MDataRow t in dd.Rows)
                {
                    var v_count = t.Get<int>("V_Count");//库存量
                    var total = t.Get<int>("Total");//减少数量
                    if (total > v_count)
                    {
                        name = t.Get<string>("Name");
                    }
                }
            }
        }
    }
}
