using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public abstract class UserEntity: BaseEntity
    {
        [StringLength(128)]
        public string CreatedBy { get; set; }
        [StringLength(128)]
        public string ModifiedBy { get; set; }

        public virtual ApplicationUser CreatedUser { get; set; }
        public virtual ApplicationUser ModifiedUser { get; set; }
    }
}
