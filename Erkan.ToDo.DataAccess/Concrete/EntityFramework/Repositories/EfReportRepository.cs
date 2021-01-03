using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfReportRepository : EfGenericRepository<Report>, IReportDal
    {
        public Report GetByTaskId(int id)
        {
            using var context = new ToDoContext();
            return context.Reports.Include(I => I.Task).ThenInclude(I=>I.Importance).Where(I => I.Id == id).FirstOrDefault();
        }

        public int GetReportCountByAppUserId(int id)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(I => I.Reports).Where(I => I.AppUserId == id).SelectMany(I=>I.Reports).Count();
        }
    }
}
