using FashionModeling.DAL.Entity;
using FashionModeling.Models;
using FashionModeling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Services
{
    public class JobServices : IJobServices
    {
        UnitOfWork unitOfwork = new UnitOfWork();
        public Guid AddJob(JobRegisterModel model)
        {
            try
            {
                var result = new Jobs()
                {
                    CastingExpiryDateUtc = model.CastingExpiryDateUtc,
                    CastingFromDateUtc = model.CastingFromDateUtc,
                    CastingToDateUtc = model.CastingToDateUtc,
                    ContactEmail = model.ContactEmail,
                    ContactNumbers = model.ContactNumbers,
                    CreatedBy = model.UserId, 
                    Description = model.Description,
                     JobTitle= model.JobTitle,
                    ModifiedBy = model.UserId,
                    ShootingAddressId = model.ShootingAddressId,
                    ShootingDateUTC = model.ShootingDateUTC,
                };
                unitOfwork.JobsRepo.Insert(result);
                unitOfwork.Save();
                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditJob(JobEditModel model)
        {
            try
            {
                var result = unitOfwork.JobsRepo.Get(x => x.Id.Equals(model.JobId)).FirstOrDefault();
                if (result != null)
                {
                    result.CastingExpiryDateUtc = model.CastingExpiryDateUtc;
                    result.CastingFromDateUtc = model.CastingFromDateUtc;
                    result.CastingToDateUtc = model.CastingToDateUtc;
                    result.ContactEmail = model.ContactEmail;
                    result.ContactNumbers = model.ContactNumbers;
                    result.Description= model.Description;
                    result.JobTitle = model.JobTitle;
                    result.ModifiedBy = model.UserId;
                    result.ShootingDateUTC = model.ShootingDateUTC;                    
                }
                unitOfwork.JobsRepo.Update(result);
                return unitOfwork.Save() > 0;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JobListModel GetJob(int page, int pageSize)
        {
            var result = unitOfwork.JobsRepo.Get();
            if (result.Count() > 0)
            {
                return new JobListModel() {
                Jobslist = result.Select(x => new JobDetailsModel()
                {
                    CastingExpiryDateUtc = x.CastingExpiryDateUtc,
                    CastingFromDateUtc = x.CastingFromDateUtc,
                    CastingToDateUtc = x.CastingToDateUtc,
                    ContactEmail = x.ContactEmail,
                    ContactNumbers = x.ContactNumbers,
                    Description = x.Description,
                    JobId = x.Id,
                    JobTitle = x.JobTitle,
                    ShootingDateUTC = x.ShootingDateUTC,
                    ModifiedBy = x.ModifiedBy,
                    UserId = x.CreatedBy,
                }).ToPagedList(page,pageSize)};
            }
            return null;
        }

        public JobDetailsModel GetJobDetails(object id)
        {
            try
            {
                var result = unitOfwork.JobsRepo.Get(x => x.Id.Equals(id));
                if (result.Count() > 0)
                {
                    return result.Select(x => new JobDetailsModel()
                    {
                        CastingExpiryDateUtc = x.CastingExpiryDateUtc,
                        CastingFromDateUtc = x.CastingFromDateUtc,
                        CastingToDateUtc = x.CastingToDateUtc,
                        ContactEmail = x.ContactEmail,
                        ContactNumbers = x.ContactNumbers,
                        Description = x.Description,
                        JobId = x.Id,
                        JobTitle = x.JobTitle,
                        ShootingDateUTC = x.ShootingDateUTC,
                        ModifiedBy = x.ModifiedBy,
                        UserId=x.CreatedBy,
                    }).FirstOrDefault();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public JobEditModel GetJobEdit(object id)
        {
            try
            {
                var result = unitOfwork.JobsRepo.Get(x => x.Id.Equals(id));
                if (result.Count() > 0)
                {
                    return result.Select(x => new JobEditModel()
                    {
                        CastingExpiryDateUtc= x.CastingExpiryDateUtc,
                        CastingFromDateUtc=x.CastingFromDateUtc,
                        CastingToDateUtc=x.CastingToDateUtc,
                        ContactEmail=x.ContactEmail,
                        ContactNumbers=x.ContactNumbers,
                        Description=x.Description,
                        JobId=x.Id,
                        JobTitle=x.JobTitle,
                        ShootingDateUTC=x.ShootingDateUTC,                          
                    }).FirstOrDefault();
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
