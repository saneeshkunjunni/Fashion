using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class Dropdown
    {
        public Guid Value { get; set; }
        public string Text { get; set; }
    }
    public class DropdownList:List<Dropdown>
    {

    }
}
