using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project03
{
    /// <summary>
    /// 一些任务编程模式
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //new ParallelTest().Start();
            new AsyncDelegate().Start();
            Console.WriteLine("执行完成");
            Console.ReadLine();
        }

    }
    /// <summary>
    /// 任务并行库
    /// Parallel常用的方法有For/ForEach/Invoke三个静态方法。在C#中for/foreach循环使用十分普遍，
    /// 如果迭代不依赖与上次迭代的结果时，把迭代放在 不同的处理器上并行处理 将很大地提高运行效率
    /// </summary>
    class ParallelTest
    {
        public void Start()
        {
            ParallelFor();
            ParallelForEach();
            ParallelInvoke();
        }
        /// <summary>
        /// 如果我们想并行执行多个任务，可以使用 Parallel.Invoke(Action[] actions) 方法
        /// </summary>
        public void ParallelInvoke()
        {
            Parallel.Invoke(
                () => { Console.WriteLine(String.Format("并行执行任务1，线程Id为{0}", Thread.CurrentThread.ManagedThreadId)); },
                () => { Console.WriteLine("并行执行任务2，线程Id为" + Thread.CurrentThread.ManagedThreadId); }
            );
        }

        /// <summary>
        /// for 循环
        /// </summary>
        public void ParallelFor()
        {
            Parallel.For(1, 6, i => { Console.WriteLine(String.Format("{0}的平方为:{1}", i, i * i)); });
        }
        /// <summary>
        /// foreach
        /// </summary>
        public void ParallelForEach()
        {
            string[] strs = { "abcd", "efghj", "ppppp" };
            Parallel.ForEach(strs, i => { Console.WriteLine(string.Format("{0}的长度为:{1}", i, i.Length)); });
        }
    }
    /// <summary>
    /// 计时器   定期重复运行异步方法
    /// </summary>
    class Timor
    {
        public int count = 0;

        public void Run(object obj)
        {
            Console.WriteLine(obj + "已经运行" + count++ + "次了");
        }

        public void Start()
        {
            Timer time = new Timer(Run, "hello", 2000, 1000);
            Console.WriteLine("Timer 已经开始运行了");

        }
    }
    /// <summary>
    /// 异步委托
    /// BeginInvoke :执行BeginInvoke方法时，会线程池中获取一个独立线程来执行引用方法，
    /// 并立即返回一个实现IAsyncResult接口的对象的（该对象包含了线程池中线程运行异步方法的状态），
    /// 调用线程不阻塞，而引用方法在线程池的线程中并行执行。
    /// EndInvoke  : 获取异步方法调用返回的值，并释放资源，该方法把异步方法的返回值作为自己的返回值。
    /// 委托执行异步编程的3种模式：
    /// 等待一直到完成（wait-until-done）：在发起了异步方法，原始线程执行到EndInvoke时就中断并且等异步方法完成完成后再继续。
    /// 轮询（polling）:原始线程定期检查发起的线程是否完成（通过IAsyncResult.IsCompleted属性判断），如果没有则继续进行原始线程中的任务。
    /// 回调（callback）：原始线程一直执行，无需等待或检查发起的线程是否完成，在发起的线程中的引用方法完成之后，发起线程会调用回调方法，由回调方法在调用EndInvoke之前处理异步方法的结果。
    /// </summary>
    class AsyncDelegate
    {
        public void Start()
        {
            Break();
        }
        /// <summary>
        /// 阻塞 等待完成
        /// </summary>
        public void Break()
        {
            Mydel del = Sum;
            IAsyncResult asyncResult = del.BeginInvoke(5, 2, null, null);
            int result = del.EndInvoke(asyncResult);
            Console.WriteLine("略略略略");
            Console.WriteLine(result);
        }

        delegate int Mydel(int a, int b);

        public int Sum(int a, int b)
        {
            Thread.Sleep(3000);
            return a + b;
        }


    }
}
