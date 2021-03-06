﻿using FashionModeling.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FashionModeling.Models
{
    public class GalleryRegisterModel
    {
        [Required, Display(Name = "Description", Prompt = "Description")]
        public string Description { get; set; }
        [RequiredIf("IsVideo", false), Display(Name = "Upload", Prompt = "Upload")]
        public HttpPostedFileBase ImageFile { get; set; }
        [RequiredIf("IsVideo", true), Display(Name = "Video Url", Prompt = "Video Url")]
        public string Url { get; set; }
        public bool IsVideo{ get; set; } 
        [Required]
        public string ProfileId { get; set; }
    }
    public class GalleryEditModel
    {
        public Guid Id { get; set; }
        [Required, Display(Name = "Description", Prompt = "Description")]
        public string Description { get; set; }
        [Required, Display(Name = "Upload", Prompt = "Upload")]
        public string Url { get; set; }
        public bool IsImage { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSlider { get; set; }
        public bool IsActive { get; set; }
    }
    public class GalleryDetailsModel
    {
        public Guid Id { get; set; }
        [Required, Display(Name = "Description", Prompt = "Description")]
        public string Description { get; set; }
        [Required, Display(Name = "Upload", Prompt = "Upload")]
        public string Url { get; set; }
        public bool IsImage { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsSlider { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
    public class GalleryListModel
    {
        public PagedList<GalleryDetailsModel> GalleriesList { get; set; }
    }
}
