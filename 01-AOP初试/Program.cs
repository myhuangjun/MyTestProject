using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CYQ.Data;
using CYQ.Data.Aop;
using CYQ.Data.Tool;
using MyAopCommon;

namespace _01_AOP初试
{
    static class Program
    {
        private static string _conn = "host=127.0.0.1;Port=3306;Database=ttttt;uid=root;pwd=1234";
        /// <summary>
        /// 类似于MVC的filter
        /// </summary>
        static void Main()
        {
            //已成功(主要是webconfig的Aop)
            using (var action=new MAction("user",_conn))
            {
                var dt = action.Select();
                Console.WriteLine(dt.ToJson());
            }
            Console.ReadLine();
        }
    }
}
