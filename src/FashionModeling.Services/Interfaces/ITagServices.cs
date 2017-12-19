using FashionModeling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Interfaces
{
    public interface ITagServices
    {
        Guid AddTag(TagRegisterModel model);
        TagDetailsModel GetTagDetails(Guid id);
        TagEditModel GetTagEdit(Guid id);
        bool EditTag(TagEditModel model);
        bool DeleteTag(Guid id);
        TagListModel GetTags(int page, int pageSize, string filter);
        IEnumerable<TagDetailsModel> GetTags(Expression<Func<TagDetailsModel, bool>> filter = null);

    }
}
