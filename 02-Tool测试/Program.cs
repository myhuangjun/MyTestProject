using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CYQ.Data;
using CYQ.Data.Tool;

namespace _02_Tool测试
{
    class Program
    {
        private static string _conn = "host=127.0.0.1;Port=3306;Database=ttttt;uid=root;pwd=1234";

        static void Main(string[] args)
        {
            //var dd= DBTool.Keyword("Name", DalType.MsSql);
            //var dd = DBTool.GetColumns("User", _conn);
            //Console.WriteLine(dd.ToJson(true));
            //var dd= Console.ReadLine();
            //var f=IOHelper.Write("/1.txt", dd);
            //Console.WriteLine(f?"成功":"失败");
            using (var action = new MAction("User", _conn))
            {
                var dt = action.Select("GUID='39ea36f8-b6a0-cc5e-3b69-0c8764b247e1'");
                Console.WriteLine(dt.ToJson());
            }

            var user = new User()
            {
                Guid = "39ea36f8-b6a0-cc5e-3b69-0c8764b247e1",
                Name = "张三",
                Time = "2019-06-28"
            };
            Console.ReadLine();
        }

        public class User
        {
            public string Guid { get; set; }
            public string Time { get; set; }
            public string Name { get; set; }
        }

        public static bool Update<T>()
        {
            return false;
        }
    }
}
