using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class TagRegisterModel
    {
        public string TagName { get; set; }
        public int TagType { get; set; }
    }
    public class TagEditModel
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; }
        public int TagType { get; set; }
        public bool IsActive { get; set; }
    }
    public class TagDetailsModel
    {
        public Guid TagId { get; set; }
        public string TagName { get; set; }
        public int TagType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
    public class TagListModel
    {
        public PagedList<TagDetailsModel> TagLists { get; set; }
    }
}

