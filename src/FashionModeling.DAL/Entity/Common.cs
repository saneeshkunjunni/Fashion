using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Common : UserEntity
    {
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(512)]
        public string Description { get; set; }
        [StringLength(15)]
        public string Code { get; set; }
        [StringLength(512)]
        public string FreeText1 { get; set; }
        [StringLength(512)]
        public string FreeText2 { get; set; }
        [StringLength(255)]
        public string FreeText3 { get; set; }
        public bool IsSelected { get; set; }

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}