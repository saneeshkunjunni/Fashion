using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class AddressRegisterModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressMap { get; set; }
        public string AreaCode { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
    }
    public class AddressDetailsModel: AddressEditModel
    {
    }
    public class AddressEditModel
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressMap { get; set; }
        public string AreaCode { get; set; }
        public string State { get; set; }
        public string Suburb { get; set; }
        public Guid AddressId { get; set; }
        public bool  Status { get; set; }
    }
    public class AddressListModel
    {
        public PagedList<AddressDetailsModel> AdddressList { get; set; }
    }
}
