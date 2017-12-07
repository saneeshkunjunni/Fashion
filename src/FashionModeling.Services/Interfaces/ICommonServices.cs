using FashionModeling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Interfaces
{
    public interface ICommonServices
    {
        Guid AddCommon(CommonRegisterModel model);
        CommonDetailsModel GetCommonDetails(object id);
        CommonEditModel GetCommonEdit(object id);
        bool EditCommon(CommonEditModel model);
        CommonListModel GetCommon(int page, int pageSize);

    }
}
