using FashionModeling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Interfaces
{
    public interface IProfileServices
    {
        string AddProfile(ProfileRegisterModel model, string userId);
        ProfileDetailModel GetProfileDetails(string id);
        ProfileEditModel GetProfileEdit(string id);
        bool EditProfile(ProfileEditModel model);
        ProfileListModel GetProfile(int page, int pageSize);
    }
}
