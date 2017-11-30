using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class Common:UserEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public bool  IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
