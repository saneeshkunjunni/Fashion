using FashionModeling.Models;
using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Interfaces
{
    public interface IGalleryServices
    {
        Guid AddGallery(GalleryRegisterModel model);
        GalleryDetailsModel GetGalleryDetails(object id);
        GalleryEditModel GetGalleryEdit(object id);
        bool EditGallery(GalleryEditModel model);
        GalleryListModel GetGallery(int page, int pageSize);
    }
}
