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
    public class AddressServices : IAddressServices
    {
        UnitOfWork unitOfwork = new UnitOfWork();

        public Guid AddAddress(AddressRegisterModel model)
        {
            try
            {
                var result = new Address() {
                    AddressLine1 = model.AddressLine1,
                    AddressLine2= model.AddressLine2,
                    AddressMap =model.AddressMap,
                    AreaCode =model.AreaCode,
                    State= model.State,
                    Suburb=model.Suburb,
                    Status=true,
                };
                unitOfwork.AddressRepo.Insert(result);
                if (unitOfwork.Save() > 0)
                {
                    return result.Id;
                }
                return Guid.Empty;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteAddress(Guid id)
        {
            try
            {
                unitOfwork.AddressRepo.Delete(id);                 
                return unitOfwork.Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditAddress(AddressEditModel model)
        {
            try
            {
                var entity = unitOfwork.AddressRepo.Get(x => x.Id.Equals(model.AddressId)).FirstOrDefault();

                entity.AddressLine1 = model.AddressLine1;
                entity.AddressLine2 = model.AddressLine2;
                entity.AddressMap = model.AddressMap;
                entity.AreaCode = model.AreaCode;
                entity.State = model.State;
                entity.Suburb = model.Suburb;
                entity.Status = model.Status;                
                unitOfwork.AddressRepo.Update(entity);
                return unitOfwork.Save() > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AddressListModel GetAddress(int page, int pageSize, string filter)
        {
            try
            {
                var result = unitOfwork.AddressRepo.Get().Select(x=> new AddressDetailsModel()
                {
                    AddressId=x.Id,
                    AddressLine1 = x.AddressLine1,
                    AddressLine2=x.AddressLine2,
                    AddressMap=x.AddressMap,
                    AreaCode=x.AreaCode,
                    State=x.State,
                    Status=x.Status,
                    Suburb=x.Suburb,
                }).OrderBy(x=>x.AddressLine1).ToPagedList(page,pageSize);

                return new AddressListModel() { AdddressList = result  };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AddressDetailsModel GetAddressDetails(Guid id)
        {
            try
            {
                var result = unitOfwork.AddressRepo.Get(x => x.Id.Equals(id)).Select(x => new AddressDetailsModel()
                {
                    AddressId = x.Id,
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    AddressMap = x.AddressMap,
                    AreaCode = x.AreaCode,
                    State = x.State,
                    Status = x.Status,
                    Suburb = x.Suburb,
                }).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AddressEditModel GetAddressEdit(Guid id)
        {
            try
            {
                var result = unitOfwork.AddressRepo.Get(x => x.Id.Equals(id)).Select(x => new AddressEditModel()
                {
                    AddressId = x.Id,
                    AddressLine1 = x.AddressLine1,
                    AddressLine2 = x.AddressLine2,
                    AddressMap = x.AddressMap,
                    AreaCode = x.AreaCode,
                    State = x.State,
                    Status = x.Status,
                    Suburb = x.Suburb,
                }).FirstOrDefault();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
