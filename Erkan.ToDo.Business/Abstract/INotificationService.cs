using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Abstract
{
    public interface INotificationService : IGenericService<Notification>
    {
        List<Notification> GetUnread(int appUserId);
        int GetUnreadCountByAppUserId(int appUserId);
    }
}
