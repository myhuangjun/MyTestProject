using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ActionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("************同步开始***********");
            //Oper();
            //Console.WriteLine("***************结束*************");
            Console.WriteLine("************异步开始***********");
            Action action = ()=>Oper();
            action.BeginInvoke(null, null);
            Console.WriteLine("***************结束*************");
            Console.ReadLine();

        }

        public static void Oper()
        {
            Console.WriteLine("开始计算:1+1=");
            Thread.Sleep(3000);
            Console.WriteLine("算出来了:2");
        }
    }
}
