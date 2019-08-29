using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonAttribute
{
    public class BaseAttribute:Attribute
    {
        private string Name { get; set; }
        public BaseAttribute(string name)
        {
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }
    }
}
