using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class AddressRegisterModel
    {
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }        
        public string AddressMap { get; set; }
        [Required]
        public string AreaCode { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Suburb { get; set; }
    }
    public class AddressDetailsModel: AddressEditModel
    {
    }
    public class AddressEditModel
    {
        [Required]
        public string AddressLine1 { get; set; }
        [Required]
        public string AddressLine2 { get; set; }
        public string AddressMap { get; set; }
        [Required]
        public string AreaCode { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Suburb { get; set; }
        [Required]
        public Guid AddressId { get; set; }
        public bool  Status { get; set; }
    }
    public class AddressListModel
    {
        public PagedList<AddressDetailsModel> AdddressList { get; set; }
    }
}
