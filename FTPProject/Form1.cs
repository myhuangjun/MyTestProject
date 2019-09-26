using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FTPProject
{
    public partial class Form1 : Form
    {
        FTPHelper Helper = new FTPHelper();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = txt_value.Text;
            if (string.IsNullOrEmpty(text))
            {
                txt_value.Focus();
                MessageBox.Show("请输入文件名称");
                return;
            }
            var result = Helper.DownLoad(text);
            lab_result.Text += result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var text = txt_value.Text;
            if (string.IsNullOrEmpty(text))
            {
                txt_value.Focus();
                MessageBox.Show("请输入内容");
                return;
            }
            var fileName = text.Substring(0, 1) + ".txt";
            var f=Helper.UpLoad(fileName,text);
            lab_result.Text += f ? "上传成功" : "上传失败";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var text = txt_value.Text;
            if (string.IsNullOrEmpty(text))
            {
                txt_value.Focus();
                MessageBox.Show("请输入文件夹名称");
                return;
            }
            var result = Helper.Exists(text);
            lab_result.Text += result?"存在":"不存在";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var text = txt_value.Text;
            if (string.IsNullOrEmpty(text))
            {
                txt_value.Focus();
                MessageBox.Show("请输入文件夹名称");
                return;
            }
            var result = Helper.CreateDir(text);
            lab_result.Text += result ? "成功" : "失败";
        }
    }
}
