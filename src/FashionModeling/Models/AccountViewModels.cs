using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
namespace FashionModeling.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            TagItems = new List<System.Web.Mvc.SelectListItem>();
            CategoryList = new List<System.Web.Mvc.SelectListItem>();
            FluentLanguageList = new List<System.Web.Mvc.SelectListItem>();
            HairColorList = new List<System.Web.Mvc.SelectListItem>();
            EyeColorList = new List<System.Web.Mvc.SelectListItem>();
            ExperinceList = new List<System.Web.Mvc.SelectListItem>();
            SpecialFeatureList = new List<System.Web.Mvc.SelectListItem>();
        }
        [Required]
        [Display(Name = "First Name", Prompt = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name", Prompt = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Category", Prompt = "Category")]
        public Guid Category { get; set; }

        public List<System.Web.Mvc.SelectListItem> CategoryList { get; set; }
        [Required]
        [Display(Name = "Tags", Prompt = "Tags")]
        public List<string> Tags { get; set; }

        public List<System.Web.Mvc.SelectListItem> TagItems { get; set; }
        [Required]
        [Display(Name = "Nationality by Born / Ethnicity", Prompt = "Nationality by Born / Ethnicity")]
        public Guid NationalityByBirth { get; set; }
        [Required]
        [Display(Name = "Nationality by Passport(Not Visisble to public)", Prompt = "Nationality by Passport(Not Visisble to public)")]
        public Guid NationalityByPassport { get; set; }

        [Required]
        [Display(Name = "Date of Birth",Prompt ="Date of Birth")]
        public DateTime Dob { get; set; }
        [Display(Name = "Willing to Travel ?", Prompt = "Willing to Travel ?")]
        public bool WillToTravel { get; set; }
        [Display(Name = " Ethnicity (You can choose only one)", Prompt = " Ethnicity (You can choose only one)")]
        public Guid Ethnicity { get; set; }
        [Required]
        [Display(Name = "Fluent Spoken Language",Prompt = "Fluent Spoken Language")]
        public List<string> FluentLanguages { get; set; }
        public List<System.Web.Mvc.SelectListItem> FluentLanguageList { get; set; }
        [Required]
        [Display(Name = "Hair Color",Prompt = "Hair Color")]
        public Guid HairColor { get; set; }
        public List<System.Web.Mvc.SelectListItem> HairColorList { get; set; }
        [Required]
        [Display(Name = "Eye Color", Prompt = "Eye Color")]
        public Guid EyeColor { get; set; }
        public List<System.Web.Mvc.SelectListItem> EyeColorList { get; set; }
        [Required]
        [Display(Name = "Height (20 to 220 cm)", Prompt = "Height")]
        public string Height { get; set; }
        [Required]
        [Display(Name = "Shoe Size (15 to 48 EU)", Prompt = "Shoe Size")]
        public string ShoeSize { get; set; }
        [Required]
        [Display(Name = "Chest Size (46 to 250 cm) ", Prompt = "Chest Size")]
        public string ChestSize { get; set; }
        [Required]
        [Display(Name = "Waist Size (45 to 250 cm)",Prompt = "Waist Size (45 to 250 cm)")]
        public string WaistSize{ get; set; }
        [Required]
        [Display(Name = "Hips Size (45 to 250 cm)", Prompt = "Hips Size")]
        public string HipsSize { get; set; }
        [Required]
        [Display(Name = "Tshirt Size",Prompt = "Tshirt Size")]
        public string TshirtSize { get; set; }
        [Required]
        [Display(Name = "Pant Size (24 to 45 EU)", Prompt = "Pant Size")]
        public string PantSize { get; set; }
        [Required]
        [Display(Name = "Jacket Size", Prompt = "Jacket Size")]
        public string JacketSize { get; set; }
        [Required]
        [Display(Name = "Special Features", Prompt = "Special Features")]
        public Guid SpecialFeatures { get; set; }
        public List<System.Web.Mvc.SelectListItem> SpecialFeatureList { get; set; }
        [Required]
        [Display(Name = "Level of experience",Prompt = "Level of experience")]
        public Guid Experince { get; set; }
        public List<System.Web.Mvc.SelectListItem> ExperinceList { get; set; }

        [Required]
        [Display(Name = "Address Line1", Prompt = "Address Line1")]
        public string AddressLine1 { get; set; }
        [Required]
        [Display(Name = "Address Line2", Prompt = "Address Line2")]
        public string AddressLine2 { get; set; }
        [Required]
        [Display(Name = "Address Map", Prompt = "Address Map")]
        public string AddressMap { get; set; }
        [Required]
        [Display(Name = "Area Code", Prompt = "Area Code")]
        public string AreaCode { get; set; }
        [Required]
        [Display(Name = "State", Prompt = "State")]
        public string State { get; set; }
        [Required]
        [Display(Name = "Suburb", Prompt = "Suburb")]
        public string Suburb { get; set; }
        [Required]
        [Display(Name = "Mobile Number", Prompt = "Mobile Number")]
        public string MobileNumber { get; set; }
        [Required]
        [Display(Name = "WhatsApp Number", Prompt = "WhatsApp Number")]
        public string WhatsApp { get; set; } 
        [Display(Name = "Facebook Profile", Prompt = "Facebook Profile")]
        public string FacebookLink { get; set; }
        [Display(Name = "Instagram Profile", Prompt = "Instagram Profile")]
        public string InstagramLink { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name = "Email", Prompt = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
