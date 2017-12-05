using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Subscription
    {
        public long Id { get; set; }
        public string EmailAddress { get; set; }
        public bool Status { get; set; }
    }
}
