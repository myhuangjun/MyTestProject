using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project02
{
    #region ...
    /* Task:.net4.0 微软极力推荐使用Task来执行异步任务
     * .net5.0推出了async/await，让异步编程更为方便
     */
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            //线程池举例:ThreadPool相对于Thread来说可以减少线程的创建，有效减小系统开销；
            //但是ThreadPool不能控制线程的执行顺序，我们也不能获取线程池内线程取消/异常/完成的通知，
            //即我们不能有效监控和控制线程池中的线程。
            //for (int i = 0; i < 10; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(new WaitCallback((obj) =>
            //    {
            //        Console.WriteLine("第" + obj + "任务执行");
            //    }), i);
            //}
            var test=new TaskTest();
            //new TaskTest().Start();
            //new TaskTest().StartWithResult();
            //test.TaskWithWait();
            //test.TaskWithWhen();
            //test.TaskCancel();
            var asy=new AsyncTest();
            asy.Start();
            Console.WriteLine("执行主线程");
            Console.ReadKey();
        }

        /// <summary>
        /// Task举例
        /// </summary>
        class TaskTest
        {
            /// <summary>
            /// 取消Task   CancellationTokenSource 类来取消任务
            /// </summary>
            public void TaskCancel()
            {
                #region 直接取消
                //CancellationTokenSource source = new CancellationTokenSource();
                //int index = 0;
                //Task t1 = new Task(() =>
                //{
                //    while (!source.IsCancellationRequested)
                //    {
                //        Thread.Sleep(1000);
                //        Console.WriteLine("第" + (index++) + "次执行,线程运行中......");
                //    }
                //});
                //t1.Start();
                //Thread.Sleep(5000);
                //source.Cancel();
                #endregion

                #region 回调
                CancellationTokenSource source = new CancellationTokenSource();
                source.Token.Register(() => { Console.WriteLine("任务被取消后执行xx操作！"); });
                int index = 0;
                Task t1 = new Task(() =>
                {
                    while (!source.IsCancellationRequested)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("第" + (index++) + "次执行,线程运行中......");
                    }
                });
                t1.Start();
                source.CancelAfter(5000);
                #endregion
            }

            /// <summary>
            /// 延续Task 不会阻塞线程 (WhenAny/WhenAll/ContinueWith)
            /// WhenAll 所有Task完成后执行后续操作
            /// WhenAny  完成一个就执行后续
            /// </summary>
            public void TaskWithWhen()
            {
                var t1 = new Task(() =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("线程1执行完毕！");
                });
                t1.Start();
                var t2 = new TaskFactory().StartNew(() =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("线程2执行完毕！");
                });
                Task.WhenAny(t1, t2).ContinueWith((t) =>
                {
                    Thread.Sleep(100);
                    Console.WriteLine("执行后续操作完毕！");
                });

            }

            /// <summary>
            /// 阻塞 Task
            /// WaitAny 等待其中一个
            /// WaitAll  等待所有
            /// Wait  等待当前完成
            /// </summary>
            public void TaskWithWait()
            {
                var t1=new Task(() =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("线程1执行完毕！");
                });
                t1.Start();
                var  t2=new TaskFactory().StartNew(() =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine("线程2执行完毕！");
                });
                Task.WaitAny(new Task[] {t1, t2});
            }

            /// <summary>
            /// 有返回值
            /// task.Resut获取结果时会阻塞线程，即如果task没有执行完成，会等待task执行完成获取到Result，
            /// 然后再执行后边的代码
            /// </summary>
            public void StartWithResult()
            {
                //1.new方式实例化一个Task，需要通过Start方法启动
                Task<string> t1 = new Task<string>(() =>
                {
                    Thread.Sleep(1000);
                    return "T1 id为:" + Thread.CurrentThread.ManagedThreadId;
                });
                t1.Start();
                //t1.RunSynchronously(); 同步执行
                Console.WriteLine(t1.Result);
                //2.Task.Factory.StartNew(Action action)创建和启动一个Task
                Task<string> t2 = Task.Factory.StartNew<string>(() =>
                {
                    Thread.Sleep(1000);
                    return "T2 id为:" + Thread.CurrentThread.ManagedThreadId;
                });
                Console.WriteLine(t2.Result);

                //3.Task.Run(Action action)将任务放在线程池队列，返回并启动一个Task
                Task<string> t3 = Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    return "T3 id为:" + Thread.CurrentThread.ManagedThreadId;
                });
                Console.WriteLine(t3.Result);
            }
            /// <summary>
            /// 没有返回值
            /// </summary>
            public void Start()
            {
                //1.new方式实例化一个Task，需要通过Start方法启动
                Task t1 = new Task(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("T1 id为:" + Thread.CurrentThread.ManagedThreadId);
                });
                t1.Start();

                //2.Task.Factory.StartNew(Action action)创建和启动一个Task
                Task t2 = Task.Factory.StartNew(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("T2 id为:" + Thread.CurrentThread.ManagedThreadId);
                });

                //3.Task.Run(Action action)将任务放在线程池队列，返回并启动一个Task
                Task t3 = Task.Run(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("T3 id为:" + Thread.CurrentThread.ManagedThreadId);
                });

            }
        }
        /// <summary>
        /// 在C#5.0中出现的 async和await ，让异步编程变得更简单。我们看一个获取文件内容的栗子：
        /// 异步方法中方法签名返回值为Task<T>，代码中的返回值为T
        /// 异步方法签名的返回值有以下三种：
        /// Task<T>：如果调用方法想通过调用异步方法获取一个T类型的返回值，那么签名必须为Task<TResult>；
        /// ② Task:如果调用方法不想通过异步方法获取一个值，仅仅想追踪异步方法的执行状态，那么我们可以设置异步方法签名的返回值为Task;
        /// ③ void:如果调用方法仅仅只是调用一下异步方法，不和异步方法做其他交互，我们可以设置异步方法签名的返回值为void，这种形式也叫做“调用并忘记”。
        /// </summary>
        class AsyncTest
        {
            public void Start()
            {
                string content = AsyncGetContent("Test.txt").Result;
                //string content = GetContent("Test.txt");
                Console.WriteLine(content);
            }

            public async Task<string> AsyncGetContent(string fileName)
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);
                var bytes = new byte[fs.Length];
                Console.WriteLine("开始读文件");
                int len = await fs.ReadAsync(bytes, 0, bytes.Length);
                string result = Encoding.UTF8.GetString(bytes);
                return result;
            }

            /// <summary>
            /// 同步获取内容
            /// </summary>
            /// <returns></returns>
            public string GetContent(string fileName)
            {
                FileStream fs=new FileStream(fileName,FileMode.Open);
                var bytes = new byte[fs.Length];
                //Read方法读取,阻塞线程
                int len = fs.Read(bytes, 0, bytes.Length);
                string result = Encoding.UTF8.GetString(bytes);
                return result;
            }
        }
    }
}
