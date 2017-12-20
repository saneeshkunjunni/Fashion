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
        CommonDetailsModel GetCommonDetails(Guid id);
        CommonEditModel GetCommonEdit(Guid id);
        bool EditCommon(CommonEditModel model);
        bool DeleteCommon(Guid id);        
        CommonListModel GetCommon(string type,int page, int pageSize,string filter);

    }
}
