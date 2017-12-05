using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class JobRoles:UserEntity
    {
        public string RoleName { get; set; }
        public string Professions { get; set; }
        public string Gender { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public string BasedIn { get; set; }
        public bool Status { get; set; }
    }
}
