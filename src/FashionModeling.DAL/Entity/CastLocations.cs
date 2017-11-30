using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class CastLocations:UserEntity
    {
        public Guid JobId { get; set; }
        public Guid AddressId { get; set; }

        public virtual Jobs Job { get; set; }
        public virtual Address Address { get; set; }
    }
}
