using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class JobRoles:UserEntity
    {
        public Guid JobId { get; set; }
        [StringLength(255)]
        public string RoleName { get; set; }
        [StringLength(512)]
        public string Professions { get; set; }
        [StringLength(255)]
        public string Gender { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        [StringLength(255)]
        public string BasedIn { get; set; }
        public bool Status { get; set; }
        public virtual Jobs Job { get; set; }
    }
}
