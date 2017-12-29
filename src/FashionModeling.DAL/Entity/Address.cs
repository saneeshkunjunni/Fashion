using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Address : UserEntity
    {
        [StringLength(512)]
        public string AddressLine1 { get; set; }
        [StringLength(512)]
        public string AddressLine2 { get; set; }
        [StringLength(512)]
        public string AddressMap { get; set; }
        [StringLength(20)]
        public string AreaCode { get; set; }
        [StringLength(255)]
        public string State { get; set; }
        [StringLength(255)]
        public string Suburb { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Jobs> Jobs { get; set; }
    }
}
