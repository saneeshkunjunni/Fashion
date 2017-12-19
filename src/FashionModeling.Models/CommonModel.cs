using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class CommonRegisterModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public bool IsSelected { get; set; }
    }
    public class CommonDetailsModel
    {
        public Guid CommonId { get; set; } 
        public DateTime CreatedUTCDate { get; set; } 
        public DateTime ModifiedUTCDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public bool IsSelected { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }        
        public string ModifiedBy { get; set; }
    }
    public class CommonEditModel
    {
        public Guid CommonId { get; set; }        
        public string Title { get; set; }
        public string Description { get; set; }
        public string FreeText1 { get; set; }
        public string FreeText2 { get; set; }
        public string FreeText3 { get; set; }
        public bool IsSelected { get; set; }
        public string Code { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class CommonListModel
    {
        public PagedList<CommonDetailsModel> CommonList { get; set; }
    }
    
}
