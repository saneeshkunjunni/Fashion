using FashionModeling.Models;
using FashionModeling.Models.Helpers;
using FashionModeling.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace FashionModeling.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IJobServices jobServices;
        private readonly IAddressServices addressServices;
        private readonly ITagServices tagServices;
        private readonly ICommonServices commonServices;
        private readonly IDropdownServices dropdownServices;
        private ApplicationUserManager userManager;
        public AdminController(ApplicationUserManager userManager, IDropdownServices dropdownServices, IJobServices jobServices,IAddressServices addressServices, ITagServices tagServices, ICommonServices commonServices)
        {
            this.jobServices = jobServices;
            this.addressServices = addressServices;
            this.tagServices = tagServices;
            this.commonServices = commonServices;
            this.dropdownServices = dropdownServices;
            this.userManager = userManager;
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region Address
        public ActionResult Address(int page=1,int pageSize = 20, string filter =null)
        {
            return View(addressServices.GetAddress(page,pageSize,filter));
        }

        public ActionResult AddAddress()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAddress(AddressRegisterModel model)
        {            
            if (ModelState.IsValid)
            {
                if (addressServices.AddAddress(model) != Guid.Empty)
                {
                    return Redirect("Address"); 
                }
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult EditAddress(string id)
        {
            Guid addressId = Guid.Empty;
            if (Guid.TryParse(id, out addressId))
            {
                return View(addressServices.GetAddressEdit(addressId));
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditAddress(AddressEditModel model)
        {

            if (ModelState.IsValid)
            {
                if (addressServices.EditAddress(model))
                {
                    return RedirectToAction("Address");
                }
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult AddressDetails(string id)
        {
            Guid addressId = Guid.Empty;
            if (Guid.TryParse(id, out addressId))
            {
                return View(addressServices.GetAddressDetails(addressId));
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult DeleteAddress(string id)
        {
            Guid addressId = Guid.Empty;
            if (Guid.TryParse(id, out addressId))
            {
                var result = addressServices.DeleteAddress(addressId);
                if (result && Request.IsAjaxRequest())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else if (result)
                {
                    return RedirectToAction("Address");
                }
                else if (Request.IsAjaxRequest())
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("Address");
                }
            }
            return HttpNotFound();
        }
        #endregion

        #region Job
        public ActionResult Job(int page = 1, int pageSize = 20, string filter = null)
        {
            return View(jobServices.GetJob(page, pageSize, filter));
        }

        public ActionResult AddJob()
        {
            var model = new JobRegisterModel();
            model.AddressList.AddRange(dropdownServices.GetAddress());
            return View(model);
        }
        [HttpPost]
        public ActionResult AddJob(JobRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("FinalJob", model);
                //model.UserId = User.Identity.GetUserId();
                //if (jobServices.AddJob(model) != Guid.Empty)
                //{
                //    return Redirect("Job");
                //} 
            }
            model.AddressList.AddRange(dropdownServices.GetAddress());
            return View(model);
        }
        [HttpPost]
        public ActionResult CropJobImage(
            string imagePath,
            int? cropPointX,
            int? cropPointY,
            int? imageCropWidth,
            int? imageCropHeight)
        {
            if (string.IsNullOrEmpty(imagePath)
                || !cropPointX.HasValue
                || !cropPointY.HasValue
                || !imageCropWidth.HasValue
                || !imageCropHeight.HasValue)
            {
                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
            }

            byte[] imageBytes = System.IO.File.ReadAllBytes(Server.MapPath(imagePath));
            byte[] croppedImage = ImageHelper.CropImage(imageBytes, cropPointX.Value, cropPointY.Value, imageCropWidth.Value, imageCropHeight.Value);

            string tempFolderName = Server.MapPath("~/" + System.Configuration.ConfigurationManager.AppSettings["Image.TempFolderName"]);

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(imagePath);
            string fileName = Path.GetFileName(imagePath).Replace(fileNameWithoutExtension, fileNameWithoutExtension + "_cropped");

            try
            {
                FileHelper.SaveFile(croppedImage, Path.Combine(tempFolderName, fileName));
            }
            catch (Exception)
            {
                //Log an error     
                return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
            }

            string photoPath = string.Concat("/", System.Configuration.ConfigurationManager.AppSettings["Image.TempFolderName"], "/", fileName);
            return Json(new { photoPath = photoPath }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult JobImage()
        {
            HttpPostedFileBase myFile = Request.Files["ImageFile"];
            bool isUploaded = false;

            string tempFolderName = System.Configuration.ConfigurationManager.AppSettings["Image.TempFolderName"];

            if (myFile != null && myFile.ContentLength != 0)
            {
                string tempFolderPath = Server.MapPath("~/" + tempFolderName);

                if (FileHelper.CreateFolderIfNeeded(tempFolderPath))
                {
                    try
                    {
                        myFile.SaveAs(Path.Combine(tempFolderPath, myFile.FileName));
                        isUploaded = true;
                    }
                    catch (Exception) {  /*TODO: You must process this exception.*/}
                }
            }

            string filePath = string.Concat("/", tempFolderName, "/", myFile.FileName);
            return Json(new { isUploaded, filePath }, "text/html");

        }
        public ActionResult FinalJob(JobRegisterModel model)
        {
            var rolemodel = new JobRegisterWithRole()
            {
                CastingExpiryDateUtc = model.CastingExpiryDateUtc,
                CastingFromDateUtc = model.CastingFromDateUtc,
                CastingToDateUtc = model.CastingToDateUtc,
                ContactEmail = model.ContactEmail,
                ContactNumbers = model.ContactNumbers,
                Description = model.Description,
                JobTitle = model.JobTitle,
                NumberOfRoles = model.NumberOfRoles,
                ShootingAddressId = model.ShootingAddressId,
                ShootingDateUTC = model.ShootingDateUTC,
            }; 
            var item = new JobRoleRegisterModel();
            item.CountryList.AddRange(dropdownServices.GetNationalities());
            item.ProfessionList.AddRange(dropdownServices.GetTags());
            item.GenderList.AddRange(dropdownServices.GetGenders());
            for (int i = 0; i < model.NumberOfRoles; i++)
            {   
                rolemodel.JobRoles.Add(item);
            }
            
            return View(rolemodel);
        }
        [HttpPost]
        public ActionResult FinalJob(JobRegisterWithRole model)
        {
            if (ModelState.IsValid)
            {
                model.UserId = User.Identity.GetUserId();
                if (jobServices.AddJob(model) != Guid.Empty)
                {
                    return Redirect("Job");
                }
                return RedirectToAction("AddJob");
            }
            foreach (var item in model.JobRoles)
            {
                item.CountryList.AddRange(dropdownServices.GetNationalities());
                item.ProfessionList.AddRange(dropdownServices.GetTags());
                item.GenderList.AddRange(dropdownServices.GetGenders());
            }
            return View(model);
        }
        public ActionResult EditJob(string id)
        {
            Guid addressId = Guid.Empty;
            if (Guid.TryParse(id, out addressId))
            {
                var model = jobServices.GetJobEdit(addressId);
                model.AddressList.AddRange(dropdownServices.GetAddress());
                return View();
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditJob(JobEditModel model)
        {

            if (ModelState.IsValid)
            {
                model.UserId = User.Identity.GetUserId();
                if (jobServices.EditJob(model))
                { 
                    return RedirectToAction("Job");
                }
                return HttpNotFound();
            }
            model.AddressList.AddRange(dropdownServices.GetAddress());
            return View(model);
            
        }
        public ActionResult JobDetails(string id)
        {
            Guid addressId = Guid.Empty;
            if (Guid.TryParse(id, out addressId))
            {
                return View(jobServices.GetJobDetails(addressId));
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult DeleteJob(string id)
        {
            Guid addressId = Guid.Empty;
            if (Guid.TryParse(id, out addressId))
            {
                var result = jobServices.DeleteJob(addressId);
                if (result && Request.IsAjaxRequest())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else if (result)
                {
                    return RedirectToAction("Job");
                }
                else if (Request.IsAjaxRequest())
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("Job");
                }
            }
            return HttpNotFound();
        }
        #endregion


        #region Profiles
        public ActionResult Profiles()
        {
            return View();
        }
        #endregion

        #region Subscriptions
        public ActionResult Subscriptions()
        {
            return View();
        }
        #endregion

        #region JobRoles
        public ActionResult JobRoles()
        {
            return View();
        }
        #endregion

        #region Tags 
        public ActionResult Tags(int page = 1, int pageSize = 20, string filter = null)
        {
            return View(tagServices.GetTags(page, pageSize, filter));
        }

        public ActionResult AddTags()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTags(TagRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (tagServices.AddTag(model) != Guid.Empty)
                {
                    return Redirect("Tags");
                }
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult EditTags(string id)
        {
            Guid TagsId = Guid.Empty;
            if (Guid.TryParse(id, out TagsId))
            {
                return View(tagServices.GetTagEdit(TagsId));
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditTags(TagEditModel model)
        {

            if (ModelState.IsValid)
            {
                if (tagServices.EditTag(model))
                {
                    return RedirectToAction("Tags");
                }
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult TagDetails(string id)
        {
            Guid TagsId = Guid.Empty;
            if (Guid.TryParse(id, out TagsId))
            {
                return View(tagServices.GetTagDetails(TagsId));
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult DeleteTags(string id)
        {
            Guid TagsId = Guid.Empty;
            if (Guid.TryParse(id, out TagsId))
            {
                var result = tagServices.DeleteTag(TagsId);
                if (result && Request.IsAjaxRequest())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else if (result)
                {
                    return RedirectToAction("Tags");
                }
                else if (Request.IsAjaxRequest())
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("Tags");
                }
            }
            return HttpNotFound();
        }
        #endregion

        #region Common 
        public ActionResult Common(string type,int page = 1, int pageSize = 20, string filter = null)
        {
            var data = commonServices.GetCommon(type, page, pageSize, filter);
            ViewBag.Title = data.CommonList.Count > 0 ? data.CommonList.FirstOrDefault().Description : type;
            ViewBag.Page = data.CommonList.Count > 0 ? data.CommonList.FirstOrDefault().Code : type;
            return View(data);
        }

        public ActionResult AddCommon(string type)
        {
            return View(new CommonRegisterModel() { Code=type});
        }
        [HttpPost]
        public ActionResult AddCommon(CommonRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (commonServices.AddCommon(model) != Guid.Empty)
                {
                    return Redirect("Common");
                }
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult EditCommon(string id)
        {
            Guid CommonId = Guid.Empty;
            if (Guid.TryParse(id, out CommonId))
            {
                return View(commonServices.GetCommonEdit(CommonId));
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditCommon(CommonEditModel model)
        {

            if (ModelState.IsValid)
            {
                if (commonServices.EditCommon(model))
                {
                    return RedirectToAction("Common");
                }
                return HttpNotFound();
            }
            else
            {
                return View(model);
            }
        }
        public ActionResult CommonDetails(string id)
        {
            Guid CommonId = Guid.Empty;
            if (Guid.TryParse(id, out CommonId))
            {
                return View(commonServices.GetCommonDetails(CommonId));
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult DeleteCommon(string id)
        {
            Guid CommonId = Guid.Empty;
            if (Guid.TryParse(id, out CommonId))
            {
                var result = commonServices.DeleteCommon(CommonId);
                if (result && Request.IsAjaxRequest())
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
                else if (result)
                {
                    return RedirectToAction("Common");
                }
                else if (Request.IsAjaxRequest())
                {

                    return Json(false, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return RedirectToAction("Common");
                }
            }
            return HttpNotFound();
        }
        #endregion

        #region Users
        public ActionResult Users(int page = 1, int pageSize = 20, string filter = null)
        {
            var users = userManager.Users.Select(x=> new UserDetailsModel()
            {
                EmailId = x.Email,
                UserName = x.UserName,
                WhatsAppNumber = x.Profile != null ? x.Profile.WhatsAppNumber : "",
                IsProfileUser = x.Profile != null,
                Phone =x.PhoneNumber,
                UseId=x.Id,
            }).OrderBy(x=>x.UserName).ToPagedList(page,pageSize);
            return View(new UserListModel() { Userlist = users });
        }
        [HttpPost]
        public async Task<ActionResult> RemoveUsers(string id)
        {
            Guid TagsId = Guid.Empty;
            if (Guid.TryParse(id, out TagsId))
            {
                // id is id of the user to be deleted.
                var user = await userManager.FindByIdAsync(id); //use async find
                if (user != null)
                {
                    var result = await userManager.DeleteAsync(user);
                    return Json(result.Succeeded);
                }
                return Json(false);
            }
            return HttpNotFound();
        }       
        #endregion
    }
}