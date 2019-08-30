using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonAttribute;

namespace AopHelper
{
    public class BaseHelper
    {
        /// <summary>
        /// 创建插入语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras"></param>
        /// <param name="model"></param>
        /// <param name="key">主键(如果忽略主键, 优先判断主键是否为key,其次为KeyAttribute)</param>
        /// <param name="autoValue">主键是否为自增长</param>
        /// <returns></returns>
        public string CreateInsertSql<T>(out SqlParameter[] paras, T model, bool autoValue = false)
        {
            Type t = typeof(T);
            var tableName = t.FilterNameAttribute();
            var sql = new StringBuilder(" INSERT INTO " + tableName + " (");
            var props = t.GetProperties();
            props = props.IgnorePropertyInfos().Where(x => !x.PropertyType.IsArray).ToArray();//设置过滤条件
            if (autoValue) props = props.IgnoreKeyAttribute();
            var cols = string.Join(",", props.Select(x => x.Name));
            sql.Append(cols + ") VALUES(");
            var values = string.Join(",", props.Select(x => "@" + x.Name));
            sql.Append(values + ")");
            paras = props.Select(x => new SqlParameter("@" + x.Name, x.GetValue(model, null))).ToArray();
            return sql.ToString();
        }

        /// <summary>
        /// 创建更新语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="paras"></param>
        /// <param name="model"></param>
        /// <param name="where">如果不为空,where条件 优先级:5</param>
        /// <param name="key">主键 如果where为空 key值为主键条件 优先级:4</param>
        /// 如果上面都为空  自动查找类中Key值为where
        /// <returns></returns>
        public string CreateUpdateSql<T>(out SqlParameter[] paras, T model, string where = "")
        {
            bool ignoreKey = true;  //是否忽略主键
            Type t = typeof(T);
            var tableName = t.FilterNameAttribute();
            var sql = new StringBuilder(" Update " + tableName + " set ");
            var props = t.GetProperties();
            props = props.Where(x => !x.PropertyType.IsArray).ToArray();//设置过滤条件
            var cols = string.Join(",", props.IgnoreKeyAttribute().Select(x => x.Name + "=@" + x.Name));
            sql.Append(cols + " where ");
            #region 判断where条件
            if (!string.IsNullOrEmpty(where))
                sql.Append(where);
            else
            {
                var keyCol = props.FirstOrDefault(x => x.IsDefined(typeof(KeyAttribute), false));
                if (keyCol == null) sql.Append(" and 1=2");
                else
                {
                    ignoreKey = false;
                    sql.AppendFormat(" {0}=@{0}", keyCol.Name);
                }
            }
            #endregion
            if (ignoreKey) props = props.IgnoreKeyAttribute();
            paras = props.Select(x => new SqlParameter("@" + x.Name, x.GetValue(model, null))).ToArray();
            return sql.ToString();
        }

        /// <summary>
        /// 创建删除语句
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public string CreateDeleteSql<T>(string where = "")
        {
            Type t = typeof(T);
            var tableName = t.FilterNameAttribute();
            var sql = new StringBuilder("Delete From " + tableName);
            sql.AppendFormat(" where " + where);
            return sql.ToString();
        }

        #region Mapping 数据库操作对象转实体
        /// <summary>
        /// DataTable转为列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<T> DataTableToList<T>(DataTable dt)
        {
            var list = new List<T>();
            if (dt == null || dt.Rows.Count < 1) return null;
            Type t = typeof(T);
            var props = t.GetProperties();
            foreach (DataRow row in dt.Rows)
            {
                var model = Activator.CreateInstance<T>();
                foreach (var prop in props.IgnorePropertyInfos())
                {
                    if (row[prop.FilterNameAttribute()] != DBNull.Value)
                        prop.SetValue(model, row[prop.FilterNameAttribute()], null);
                }
                list.Add(model);
            }
            return list;
        }
        #endregion

    }
    }
}
