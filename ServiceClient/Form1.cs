using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServiceClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = ConfigurationManager.AppSettings["FileName"];
            textBox2.Text = ConfigurationManager.AppSettings["Service"];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string serviceFilePath = Application.StartupPath + "\\" + textBox1.Text;
                string serviceName = textBox2.Text;
                if (this.IsServiceExisted(serviceName))
                    this.UninstallService(serviceFilePath);
                this.InstallService(serviceFilePath);
                button1.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                MessageBox.Show(this, "安装成功");
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["FileName"].Value = textBox1.Text;
                config.AppSettings.Settings["Service"].Value = serviceName;
                // Save the configuration file. 
                config.AppSettings.SectionInformation.ForceSave = true;
                config.Save(ConfigurationSaveMode.Modified);
                // Force a reload of the changed section. 
                ConfigurationManager.RefreshSection("appSettings");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "安装失败--错误信息:"+ex.Message);
            }
            
        }
        //启动
        private void button2_Click(object sender, EventArgs e)
        {
            string serviceFilePath = Application.StartupPath + "\\" + textBox1.Text;
            string serviceName = textBox2.Text;
            if (this.IsServiceExisted(serviceName)) 
                this.ServiceStart(serviceName);
            button2.Enabled = false;
            MessageBox.Show(this, "启动成功");
        }
        //停止
        private void button3_Click(object sender, EventArgs e)
        {
            string serviceFilePath = Application.StartupPath + "\\" + textBox1.Text;
            string serviceName = textBox2.Text;
            if (this.IsServiceExisted(serviceName)) 
                this.ServiceStop(serviceName);
            MessageBox.Show(this, "停止成功");

        }
        //卸载
        private void button4_Click(object sender, EventArgs e)
        {
            string serviceFilePath = Application.StartupPath + "\\" + textBox1.Text;
            string serviceName = textBox2.Text;
            if (this.IsServiceExisted(serviceName))
            {
                this.ServiceStop(serviceName);
                this.UninstallService(serviceFilePath);
            }
            MessageBox.Show(this, "卸载成功");

        }

        #region 判断是否存在

        private bool IsServiceExisted(string serviceName)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (ServiceController sc in services)
            {
                if (sc.ServiceName.ToLower() == serviceName.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 安装服务

        private void InstallService(string path)
        {
            using (AssemblyInstaller installer=new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = path;
                IDictionary saveState = new Hashtable();
                installer.Install(saveState);
                installer.Commit(saveState);
            }
        }

        #endregion

        #region 卸载服务

        public void UninstallService(string serviceFilePath)
        {
            using (AssemblyInstaller installer = new AssemblyInstaller())
            {
                installer.UseNewContext = true;
                installer.Path = serviceFilePath;
                installer.Uninstall(null);
            }
        }

        #endregion

        #region 启动服务

        public void ServiceStart(string serviceName)
        {
            using (ServiceController control=new ServiceController(serviceName))
            {
                if (control.Status == ServiceControllerStatus.Stopped)
                    control.Start();
            }
        }

        #endregion

        #region 停止服务

        public void ServiceStop(string serviceName)
        {
            using (ServiceController control=new ServiceController(serviceName))
            {
                if(control.Status==ServiceControllerStatus.Running)
                    control.Stop();
            }
        }

        #endregion

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
