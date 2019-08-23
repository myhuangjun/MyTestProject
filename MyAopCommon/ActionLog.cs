using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_AOP初试
{
    public class ActionLog
    {
        public void WriteFill(object id)
        {
        }
        public void WriteInsert(object id)
        {    
        }

        #region 其它方法
        private int GetUserID()
        {
            return 1;
        }
        private void Write(object id, string msg)
        {   
        }
        private bool ContainUrl(string key)
        {
            return false;

        }
        #endregion
    }
}
