using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonAttribute;

namespace Model
{
    [TableName("Userrrrrr")]
    public class User
    {
        
        public string Name { get; set; }
        [ColumnName("AAAAAAge")]
        public string Age { get; set; }
        public string Sex { get; set; }
    }
}
