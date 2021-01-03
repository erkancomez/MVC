using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Abstract
{
    public interface IReportService : IGenericService<Report>
    {
        Report GetByTaskId(int id);
        int GetReportCountByAppUserId(int id);
    }

}
