using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_AsyncAndAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            new AsyncDetail().Start();
            Console.ReadLine();
        }
    }

    class AsyncDetail
    {
        public void Start()
        {
            Method();
            Method2();
        }
        public async Task Method()
        {
            await Task.Run(() =>
             {
                 for (int i = 0; i < 10; i++)
                 {
                     Console.WriteLine("异步线程执行" + i + "次");
                 }
             });
        }

        public void Method2()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("同步线程执行" + i + "次");
            }
        }
    }
}
