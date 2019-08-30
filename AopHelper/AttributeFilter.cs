using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommonAttribute;

namespace AopHelper
{
    public static class AttributeFilter
    {
        /// <summary>
        /// 获取数据库表名/列明
        /// </summary>
        /// <returns></returns>
        public static string FilterNameAttribute(this MemberInfo membs)
        {
            if (!membs.IsDefined(typeof(BaseAttribute), true)) return membs.Name;
            BaseAttribute attr = (BaseAttribute)membs.GetCustomAttribute(typeof(BaseAttribute));
            return attr.GetName();
        }

        /// <summary>
        /// 过滤 Ignore特性的字段
        /// </summary>
        /// <param name="props"></param>
        /// <returns></returns>
        public static PropertyInfo[] IgnorePropertyInfos(this PropertyInfo[] props)
        {
            return props.Where(x => !x.IsDefined(typeof(IgnoreAttribute), true)).ToArray();
        }

        /// <summary>
        /// 主键 Key(更新时忽略主键)
        /// </summary>
        /// <param name="props"></param>
        /// <returns></returns>
        public static PropertyInfo[] IgnoreKeyAttribute(this PropertyInfo[] props)
        {
            return props.Where(x => !x.IsDefined(typeof(KeyAttribute), true)).ToArray();
        }

    }
}
