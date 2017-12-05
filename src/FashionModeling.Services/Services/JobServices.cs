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
                unitOfwork.Jobs.Insert(result);
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
            throw new NotImplementedException();
        }

        public JobListModel GetJob(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public JobDetailsModel GetJobDetails(object id)
        {
            throw new NotImplementedException();
        }

        public JobEditModel GetJobEdit(object id)
        {
            throw new NotImplementedException();
        }
    }
}
