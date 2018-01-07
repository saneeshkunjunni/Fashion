using FashionModeling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionModeling.Services.Interfaces
{
    public interface IJobServices
    {
        Guid AddJob(JobRegisterWithRole model);
        JobDetailsModel GetJobDetails(object id);
        JobEditModel GetJobEdit(object id);
        bool EditJob(JobEditModel model);
        JobListModel GetJob(int page, int pageSize,string filter);
        bool DeleteJob(Guid id);
    }
}
