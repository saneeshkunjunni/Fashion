using FashionModeling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Interfaces
{
    public interface IAddressServices
    {
        Guid AddAddress(AddressRegisterModel model);
        AddressDetailsModel GetAddressDetails(Guid id);
        AddressEditModel GetAddressEdit(Guid id);
        bool EditAddress(AddressEditModel model);
        bool DeleteAddress(Guid id);
        AddressListModel GetAddress(int page, int pageSize, string filter);
    }
}
