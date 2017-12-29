using FashionModeling.Models;
using FashionModeling.Services.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FashionModeling.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        GalleryServices galleryServices = new GalleryServices();
        // GET: Profile
        public ActionResult Index(int page =0)
        {
            return View();
        }
        public ActionResult Photo()
        {
            return View(galleryServices.GetGallery(1,10).GalleriesList);
        }
        public ActionResult AddPhoto()
        {
            return View(new GalleryRegisterModel() { ProfileId = User.Identity.GetUserId(), IsVideo = false });
        }
        
        [HttpPost]
        public ActionResult AddPhoto(GalleryRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                galleryServices.AddGallery(model);
            }
            return View(model);
        }
        public ActionResult AddVideo()
        {
            return View(new GalleryRegisterModel() { ProfileId = User.Identity.GetUserId(), IsVideo = true });
        }
        [HttpPost]
        public ActionResult AddVideo(GalleryRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                galleryServices.AddGallery(model);
            }
            return View(model);
        }

        public ActionResult EditPhoto(string id)
        {
            Guid modelId;
            if (!Guid.TryParse(id,out modelId))
            {
                return HttpNotFound();
            }            
            return View(galleryServices.GetGalleryEdit(modelId));
        }
        [HttpPost]
        public ActionResult EditPhoto(GalleryEditModel model)
        {
            if (ModelState.IsValid)
            {
                galleryServices.EditGallery(model);
                return RedirectToAction("Photo");
            }
            return View(model);
        }


    }
}