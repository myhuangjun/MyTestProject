using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project01
{
    /// <summary>
    /// 多线程基本概念
    /// </summary>
    class Program
    {
        #region .......
        /*
         * 进程（Process）：是系统中的一个基本概念.一个正在运行的应用程序在操作系统中被视为一个进程，包含着一个运行程序所需要的资源，进程可以包括一个或多个线程
         * 线程（Thread）：是 进程中的基本执行单元，是操作系统分配CPU时间的基本单位 ，在进程入口执行的第一个线程被视为这个进程的 主线程 。
         * 常用属性:
         *  CurrentThread	获取当前正在运行的线程。
            ExecutionContext	获取一个 ExecutionContext 对象，该对象包含有关当前线程的各种上下文的信息。
            IsBackground	bool，指示某个线程是否为后台线程。
            IsThreadPoolThread	bool，指示线程是否属于托管线程池。
            ManagedThreadId	int,获取当前托管线程的唯一标识符。
            Name	string,获取或设置线程的名称。
            Priority  获取或设置一个值，该值指示线程的调度优先级 。Lowest<BelowNormal<Normal<AboveNormal<Highest
            ThreadState	获取一个值，该值包含当前线程的状态。Unstarted、Sleeping、Running 等
         *  方法:
         *  GetDomain()	返回当前线程正在其中运行的当前域。
            GetDomainId()	返回当前线程正在其中运行的当前域Id。
            Start()　　	执行本线程。(不一定立即执行，只是标记为可以执行)
            Interrupt()	中断处于 WaitSleepJoin 线程状态的线程。
            Abort()	终结线程
            Join()	阻塞调用线程，直到某个线程终止。
            Sleep()　　	把正在运行的线程挂起一段时间。
         *
         * lock关键字: lock不能锁定空值,不能锁定string类型,值类型不能被lock,避免锁定public类型
         */
        #endregion
        static void Main(string[] args)
        {
            ThreadTest test = new ThreadTest();
            //无需调用实例方法
            //Thread t1=new Thread(test.Func2);
            //有参数的实例方法
            //Thread t1 = new Thread(test.Func1);
            //t1.Start("有参数的实例方法");
            BookShop bs = new BookShop();
            Thread t1 = new Thread(bs.Sale);
            Thread t2 = new Thread(bs.Sale);
            t1.Start();
            t2.Start();
            Console.ReadKey();
        }
    }

    class ThreadTest
    {

        public void Func2()
        {
            Console.WriteLine("这是实例方法");
        }

        public void Func1(object o)
        {
            Console.WriteLine(o);
        }
    }

    class BookShop
    {
        public int num = 1;
        private static readonly object Locker = new object();

        public void Sale()
        {
            lock (Locker)
            {
                int tem = num;
                if (tem > 0)//时候有书
                {
                    Thread.Sleep(1000);
                    num -= 1;
                    Console.WriteLine("ThreadId:" + Thread.CurrentThread.ManagedThreadId + ",出售一本书,还有" + num + "本");
                }
                else
                {
                    Console.WriteLine("没有了");
                }
            }
        }
    }
}
