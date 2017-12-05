﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Models
{
    public class JobRegisterModel
    {

        public string JobTitle { get; set; }
        public Guid ShootingAddressId { get; set; }
        public DateTime ShootingDateUTC { get; set; }
        public string ContactNumbers { get; set; }
        public string ContactEmail { get; set; }
        public DateTime CastingFromDateUtc { get; set; }
        public DateTime CastingToDateUtc { get; set; }
        public DateTime CastingExpiryDateUtc { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
    public class JobDetailsModel : JobRegisterModel
    {

    }
    public class JobEditModel : JobRegisterModel
    { 
    }
    public class JobListModel
    {
        public PagedList<JobDetailsModel> Jobslist { get; set; }
    }
}