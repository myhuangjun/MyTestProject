using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAttribute
{
    /// <summary>
    /// 列名特性
    /// </summary>
    public class ColumnNameAttribute:BaseAttribute
    {
        public ColumnNameAttribute(string name) : base(name)
        {

        }

    }
}
