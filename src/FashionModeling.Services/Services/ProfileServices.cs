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
    public class ProfileServices : IProfileServices
    {
        
        UnitOfWork unitOfWork = new UnitOfWork();
        public string AddProfile(ProfileRegisterModel model,string userId)
        {
            try
            {
                var address = new Address()
                {
                    AddressLine1 = model.AddressLine1,
                    AddressLine2=model.AddressLine2,
                    AddressMap = model.AddressMap,
                    AreaCode=model.AreaCode,
                    State = model.State,
                    Suburb = model.Suburb,
                };
                address.CreatedBy = address.ModifiedBy = userId;
                unitOfWork.AddressRepo.Insert(address);
                unitOfWork.Save();

                var tags = (from c in unitOfWork.TagRepo.Get(x => x.IsActive)
                           join d in model.Tags on c.Id equals d
                           select c).ToList();


                var result = new Profile()
                {
                    Id = userId,
                    Ethnicity = model.Ethnicity,
                    AddressId = address.Id,
                    CategoryId = model.Category,
                    Experience = model.Experince,
                    EyeColor = model.EyeColor,
                    FacebookLink = model.FacebookLink,
                    FluentLanguage = model.FluentLanguages.Aggregate((x, y) => x + ","+y),
                    HairColor=model.HairColor,
                    Height=model.Height,
                    HipSize=model.HipsSize,
                    Instagramlink = model.InstagramLink,
                    IsWillingToTravel=model.WillToTravel,
                    JacketSize=model.JacketSize,
                    NationalityByBirth =model.NationalityByBirth,
                    NationalityByPassport = model.NationalityByPassport,
                    PantSize = model.PantSize,
                    ProfilePic =model.ProfilePicsLocation,
                    ProfileUrl = model.ProfilePicsLocation,
                    ShoeSize= model.ShoeSize,
                    SpecialFeatures = model.SpecialFeatures.Aggregate((x, y) => x + "," + y),
                    Status=true,
                    Tags =tags,
                    TshirtSize=model.TshirtSize,
                    WaistSise= model.WaistSize,      
                    DateOfBirth = DateTime.ParseExact(model.Dob,"dd/MM/yyyy", new CultureInfo("en-US"), DateTimeStyles.None),
            };
                unitOfWork.ProfileRepo.Insert(result);
                unitOfWork.Save();
                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditProfile(ProfileEditModel model)
        {
            throw new NotImplementedException();
        }

        public ProfileListModel GetProfile(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public ProfileDetailModel GetProfileDetails(string id)
        {
            throw new NotImplementedException();
        }

        public ProfileEditModel GetProfileEdit(string id)
        {
            throw new NotImplementedException();
        }
    }
}
