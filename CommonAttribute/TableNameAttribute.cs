using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAttribute
{
    /// <summary>
    /// 表名特性
    /// </summary>
    public class TableNameAttribute : BaseAttribute
    {
        public TableNameAttribute(string name): base(name)
        {

        }
    }
}
