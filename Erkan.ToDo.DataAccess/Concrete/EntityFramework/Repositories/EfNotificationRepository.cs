using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        public List<Notification> GetUnread(int appUserId)
        {
            using var context = new ToDoContext();
            return context.Notifications.Where(I => I.AppUserId == appUserId && !I.Statement).ToList();
        }

        public int GetUnreadCountByAppUserId(int appUserId)
        {
            using var context = new ToDoContext();
            return context.Notifications.Count(I => I.AppUserId == appUserId && !I.Statement);
        }
    }
}
