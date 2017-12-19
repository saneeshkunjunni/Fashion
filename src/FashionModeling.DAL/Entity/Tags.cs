using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Tags:UserEntity
    {
        public Tags()
        {
            this.Galleries = new HashSet<Gallery>();
        }
        public string TagName { get; set; }
        public int TagType { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Gallery> Galleries { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
