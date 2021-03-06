﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.DAL.Entity
{
    public class JobApplications:UserEntity
    {
        public Guid AppliedFor { get; set; }
        public Guid JobRoleId { get; set; }        
        public string AboutApplicant { get; set; }
        public bool IsSelected { get; set; }
        public virtual Jobs Job { get; set; }
        public virtual JobRoles JobRole { get; set; }
    }
}
