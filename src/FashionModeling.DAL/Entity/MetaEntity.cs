using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class MetaEntity : UserEntity
    {
        [StringLength(60)]
        public string MetaTitle { get; set; }
        [StringLength(200)]
        public string MetaKeywords { get; set; }
        [StringLength(100)]
        public string MetaSubject { get; set; }
        [StringLength(160)]
        public string MetaDescription { get; set; }
    }
}
