using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
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
            var list = new List<Student>();
            list.Add(new Student()
            {
                Id = "4",
                Name = "李四",
                Sex = "11",
                Weight = "50"

            });
            list.Add(new Student()
            {
                Id = "0",
                Name = "王八",
                Sex = "110",
                Weight = "120"

            });
            using (var action = new MAction("Student"))
            {
                foreach (var item in list)
                {
                    if (action.Exists("Id='" + item.Id + "'"))
                    {
                        action.SetExpression("Weight=Weight+" + item.Weight);
                        action.Update("Id='" + item.Id + "'");
                        action.Data.Clear();
                        continue;
                    }
                    action.Set("Name", item.Name);
                    action.Set("Sex", item.Sex);
                    action.Set("Weight", item.Weight);
                    action.Set("Id", item.Id);
                    action.Insert();
                    action.Data.Clear();
                }
            }
            MessageBox.Show("22222");
        }

        //public void Update()
        //{
        //    using (var action = new MAction("Student"))
        //    {
        //        var name = textBox1.Text;
        //        action.Set("Name", DBNull.Value);
        //        action.Set("Age", 10);
        //        action.Update(" Age=10");
        //        var i = action.RecordsAffected;
        //        MessageBox.Show(i + "");
        //    }
        //}
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

    }
}
