using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Address : UserEntity
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressMap { get; set; }
        public string AreaCode { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
        public bool Status { get; set; }
    }
}
