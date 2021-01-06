using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfTaskRepository : EfGenericRepository<Task>, ITaskDal
    {
        public List<Task> GetAllTable()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(I => I.Importance).Include(I => I.Reports).Include(I => I.AppUser).Where(I => !I.Statement).OrderByDescending(I => I.CreatedDate).ToList();
        }

        public Task GetByTaskId(int id)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(I => I.Reports).Where(I => I.Id == id).Include(I=>I.AppUser).FirstOrDefault();
        }

        public List<Task> GetByAppUserId(int appUserId)
        {
            using var context = new ToDoContext();
            return context.Tasks.Where(I => I.AppUserId == appUserId).ToList();
        }

        public List<Task> GetByImportanceIncomplete()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(I => I.Importance).Where(I => !I.Statement).OrderByDescending(I => I.CreatedDate).ToList();
        }

        public Task GetImportanceById(int id)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(I => I.Importance).FirstOrDefault(I => !I.Statement && I.Id == id);
        }

        public List<Task> GetAllTable(Expression<Func<Task, bool>> filter)
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(I => I.Importance).Include(I => I.Reports).Include(I => I.AppUser).Where(filter).OrderByDescending(I => I.CreatedDate).ToList();
        }

        public List<Task> GetAllTableInCompleted(out int totalPage, int userId, int activePage=1)
        {
            using var context = new ToDoContext();
            var returnValue = context.Tasks.Include(I => I.Importance).Include(I => I.Reports).Include(I => I.AppUser).Where(I => I.AppUserId == userId && I.Statement).OrderByDescending(I => I.CreatedDate);

            totalPage =(int)Math.Ceiling((double)returnValue.Count() / 3);

            return returnValue.Skip((activePage - 1) * 3).Take(3).ToList();
        }

        public int GetCompletedTaskCountByUserId(int id)
        {
            using var context = new ToDoContext();
            return context.Tasks.Count(I => I.AppUserId == id && I.Statement);
        }

        public int GetIncompletedTaskCountByUserId(int id)
        {
            using var context = new ToDoContext();
            return context.Tasks.Count(I => I.AppUserId == id && !I.Statement);
        }

        public int GetUnAssignedTask()
        {
            using var context = new ToDoContext();
            return context.Tasks.Count(I => I.AppUserId == null && !I.Statement);
        }

        public int GetCompletedTask()
        {
            using var context = new ToDoContext();
            return context.Tasks.Count(I => I.Statement);
        }
    }
}
