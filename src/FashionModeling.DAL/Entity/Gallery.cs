using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [StringLength(512)]
        public string Description { get; set; }
        [StringLength(512)]
        public string Url { get; set; }
        public bool IsImage { get; set; }
        public bool IsActive { get; set; }
        public bool IsSlider { get; set; }
        public bool IsFeatured { get; set; }
        public Guid ProfileId { get; set; }

        public virtual Profile Profile { get; set; }

        public virtual ICollection<Tags> Tags { get; set; }
    }
}
