using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class UserDetailsModel
    {
        [Display(Name ="User Id")]
        public string UseId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "-")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Email")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "-")]
        public string EmailId { get; set; }
        [Display(Name = "Phone")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "-")]
        public string Phone { get; set; }
        [Display(Name = "What's App Number")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "-")]
        public string WhatsAppNumber { get; set; }
        public bool IsProfileUser { get; set; }
    }
    public class UserListModel
    {
        public PagedList<UserDetailsModel> Userlist { get; set; }
    }
}
