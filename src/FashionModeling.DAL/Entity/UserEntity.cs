using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FashionModeling.DAL.Entity
{
    public abstract class UserEntity: BaseEntity
    {
        [StringLength(128)]
        public string CreatedBy { get; set; } =HttpContext.Current.User.Identity.GetUserId(); // comment it for initial creation
        [StringLength(128)]
        public string ModifiedBy { get; set; } = HttpContext.Current.User.Identity.GetUserId(); // comment it for initial creation
        public virtual ApplicationUser CreatedUser { get; set; } 
        public virtual ApplicationUser ModifiedUser { get; set; }
    }
}
