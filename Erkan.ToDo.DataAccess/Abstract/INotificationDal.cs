using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DataAccess.Abstract
{
    public interface INotificationDal : IGenericDal<Notification>
    {
        List<Notification> GetUnread(int AppUserId);
    }
}
