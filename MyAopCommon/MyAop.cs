using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CYQ.Data;
using CYQ.Data.Aop;
using _01_AOP初试;

namespace MyAopCommon
{
    public class MyAop : IAop
    {
        private ActionLog log;

        public MyAop()
        {
            log = new ActionLog();
        }
        public AopResult Begin(AopEnum action, AopInfo aopInfo)
        {
            Console.WriteLine("开始方法:我已经拦截到用了方法");
            AopResult ar = AopResult.Continue;
            return ar;
        }

        public IAop Clone()
        {
            return new MyAop();
        }
        public void End(AopEnum action, AopInfo aopInfo)
        {
            if (action == AopEnum.Select)
            {
                Console.WriteLine("结束方法:我已经拦截到用了选择方法");
            }
        }
        public void OnError(string msg)
        {
            
        }

        public void OnLoad()
        {
            Console.WriteLine("已调用了加载方法");
        }
    }
}
