using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Gallery:UserEntity
    {
        public Gallery()
        {
            this.Tags = new HashSet<Tags>();
        }
        public string Description { get; set; }
        public string Url { get; set; }
        public bool IsActive { get; set; }
        public bool IsSlider { get; set; }
        public bool IsFeatured { get; set; }

        public virtual ICollection<Tags> Tags { get; set; }
    }
}
