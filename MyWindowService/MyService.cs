using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using CYQ.Data;

namespace MyWindowService
{
    public partial class MyService : ServiceBase
    {
        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Log.WriteLogToTxt("我启动了");
        }

        protected override void OnStop()
        {
            Log.WriteLogToTxt("我结束了");
        }
    }
}
