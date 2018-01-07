using FashionModeling.DAL.Entity;
using FashionModeling.Models;
using FashionModeling.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Services
{
    public class JobServices : IJobServices
    {
        UnitOfWork unitOfwork = new UnitOfWork();
        public Guid AddJob(JobRegisterWithRole model)
        {
            try
            {
                var result = new Jobs()
                {
                    CastingExpiryDateUtc = DateTime.ParseExact(model.CastingExpiryDateUtc, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None),
                    CastingFromDateUtc = DateTime.ParseExact(model.CastingFromDateUtc, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None),
                    CastingToDateUtc = DateTime.ParseExact(model.CastingToDateUtc, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None),
                    ContactEmail = model.ContactEmail,
                    ContactNumbers = model.ContactNumbers,
                    CreatedBy = model.UserId,
                    Description = model.Description,
                    JobTitle = model.JobTitle,
                    ModifiedBy = model.UserId,
                    ShootingAddressId = model.ShootingAddressId,
                    ShootingDateUTC = DateTime.ParseExact(model.ShootingDateUTC, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None),
                    Status =true,
                    JobUrl = model.Url,
                };
                unitOfwork.JobsRepo.Insert(result);
                if (unitOfwork.Save() > 0)
                {
                    var roles = new List<JobRoles>();
                    foreach (var item in model.JobRoles)
                    {
                        roles.Add(new JobRoles {
                            AgeFrom=item.AgeFrom,
                            AgeTo=item.AgeTo,
                            BasedIn=item.BasedIn.Aggregate((x, y) => x + "," + y),
                            Gender =item.Gender,
                            JobId = result.Id,
                            Professions = item.Professions.Aggregate((x, y) => x + "," + y),
                            RoleName =item.RoleName,
                            Status=true,
                        });
                    }
                    return result.Id;

                }
                return Guid.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteJob(Guid id)
        {
            try
            {
                unitOfwork.JobsRepo.Delete(id);
                return unitOfwork.Save() > 0;
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
                    result.CastingExpiryDateUtc = DateTime.ParseExact(model.CastingExpiryDateUtc, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);
                    result.CastingFromDateUtc = DateTime.ParseExact(model.CastingFromDateUtc, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);
                    result.CastingToDateUtc = DateTime.ParseExact(model.CastingToDateUtc, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);
                    result.ContactEmail = model.ContactEmail;
                    result.ContactNumbers = model.ContactNumbers;
                    result.Description = model.Description;
                    result.JobTitle = model.JobTitle;
                    result.ModifiedBy = model.UserId;
                    result.ShootingDateUTC = DateTime.ParseExact(model.ShootingDateUTC, "dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None);
                }
                unitOfwork.JobsRepo.Update(result);
                return unitOfwork.Save() > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public JobListModel GetJob(int page, int pageSize, string filter)
        {
            var result = unitOfwork.JobsRepo.Get();
            var data = result.Select(x => new JobDetailsModel()
            {
                CastingExpiryDateUtc = x.CastingExpiryDateUtc.ToString(),
                CastingFromDateUtc = x.CastingFromDateUtc.ToString(),
                CastingToDateUtc = x.CastingToDateUtc.ToString(),
                ContactEmail = x.ContactEmail,
                ContactNumbers = x.ContactNumbers,
                Description = x.Description,
                JobId = x.Id,
                JobTitle = x.JobTitle,
                ShootingDateUTC = x.ShootingDateUTC.ToString(),
                ModifiedBy = x.ModifiedBy,
                UserId = x.CreatedBy,
            }).OrderBy(x => x.JobTitle).ToPagedList(page, pageSize);


            return new JobListModel() { Jobslist = data };
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
                        CastingExpiryDateUtc = x.CastingExpiryDateUtc.ToString(),
                        CastingFromDateUtc = x.CastingFromDateUtc.ToString(),
                        CastingToDateUtc = x.CastingToDateUtc.ToString(),
                        ContactEmail = x.ContactEmail,
                        ContactNumbers = x.ContactNumbers,
                        Description = x.Description,
                        JobId = x.Id,
                        JobTitle = x.JobTitle,
                        ShootingDateUTC = x.ShootingDateUTC.ToString(),
                        ModifiedBy = x.ModifiedBy,
                        UserId = x.CreatedBy,
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
                        CastingExpiryDateUtc = x.CastingExpiryDateUtc.ToString(),
                        CastingFromDateUtc = x.CastingFromDateUtc.ToString(),
                        CastingToDateUtc = x.CastingToDateUtc.ToString(),
                        ContactEmail = x.ContactEmail.ToString(),
                        ContactNumbers = x.ContactNumbers,
                        Description = x.Description,
                        JobId = x.Id,
                        JobTitle = x.JobTitle,
                        ShootingDateUTC = x.ShootingDateUTC.ToString(),
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
