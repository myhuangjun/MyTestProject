using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project04
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> action = new AsyncWriteLog().WriteLog;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("这是第" + i + "次");
                action.Invoke("这是第" + i + "次");
            }
        }
        /// <summary>
        /// 测试  异步写日志
        /// </summary>
        class AsyncWriteLog
        {
            object _locker = new object();
            public void WriteLog(string error)
            {
                var path = Directory.GetCurrentDirectory();
                var fileName = DateTime.Now.ToString("yyyyMMdd") + ".log";
                string text = String.Format("Time:{0}\r\nMessage:{1}\r\n------------------------------", DateTime.Now, error);
                StreamWriter sw;
                lock (_locker)
                {
                    sw = File.Exists(path + "/" + fileName) ? File.AppendText(path + "/" + fileName) : File.CreateText(path + "/" + fileName);
                    sw.WriteLine(text);
                    sw.Close();
                }
            }
        }
    }
}
