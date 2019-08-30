using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AopHelper;
using Model;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseHelper helpr=new BaseHelper();
            helpr.GetList<User>(" 1=1");
        }
    }
}
