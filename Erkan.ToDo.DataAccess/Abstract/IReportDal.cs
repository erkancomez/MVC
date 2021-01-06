using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DataAccess.Abstract
{
    public interface IReportDal : IGenericDal<Report>
    {
        Report GetByTaskId(int id);
        int GetReportCountByAppUserId(int id);
        int GetReportCount();
    }
}
