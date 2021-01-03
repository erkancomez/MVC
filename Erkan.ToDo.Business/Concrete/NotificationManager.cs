using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Concrete
{
    public class NotificationManager : INotificationService
    {
        private readonly INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void Delete(Notification table)
        {
            _notificationDal.Delete(table);
        }

        public List<Notification> GetAll()
        {
            return _notificationDal.GetAll();
        }

        public Notification GetId(int Id)
        {
            return _notificationDal.GetId(Id);
        }

        public List<Notification> GetUnread(int AppUserId)
        {
            return _notificationDal.GetUnread(AppUserId);
        }

        public void Save(Notification table)
        {
            _notificationDal.Save(table);
        }

        public void Update(Notification table)
        {
            _notificationDal.Update(table);
        }
    }
}
