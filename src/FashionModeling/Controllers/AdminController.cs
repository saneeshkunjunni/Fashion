using FashionModeling.Models;
using FashionModeling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public AdminController(IJobServices jobServices,IAddressServices addressServices, ITagServices tagServices, ICommonServices commonServices)
        {
            this.jobServices = jobServices;
            this.addressServices = addressServices;
            this.tagServices = tagServices;
            this.commonServices = commonServices;
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
        public ActionResult Job()
        {
            return View();
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
        public ActionResult Users()
        {
            return View();
        }
        #endregion
    }
}