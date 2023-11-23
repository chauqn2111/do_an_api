using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary.DataAccess
{
    public class NotificationDao
    {
        private static NotificationDao instance = null;
        private static readonly object instanceLook = new object();
        public static NotificationDao Instance
        {
            get
            {
                lock (instanceLook)
                {
                    if (instance == null)
                    {
                        instance = new NotificationDao();
                    }
                    return instance;
                }
            }
        }
        public List<Notification> GetNotifications()
        {
            var listProducts = new List<Notification>();
            try
            {
                using (var context = new CookingWebsiteContext())
                {
                    listProducts = context.Notifications.ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return listProducts;
        }
        public Notification GetNotificationById(int notiId)
        {
            Notification n = new Notification();
            try
            {
                using (var context = new CookingWebsiteContext())
                {
                    n = context.Notifications.SingleOrDefault(x => x.NotificationID == notiId);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return n;
        }
        public void SaveNotification(Notification n)
        {
            try
            {
                using (var context = new CookingWebsiteContext())
                {
                    context.Notifications.Add(n);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void UpdateNotification(Notification n)
        {
            try
            {
                using (var context = new CookingWebsiteContext())
                {
                    context.Entry<Notification>(n).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void DeleteNotification(Notification n)
        {
            try
            {
                using (var context = new CookingWebsiteContext())
                {
                    var p1 = context.Notifications.SingleOrDefault(c => c.NotificationID == n.NotificationID);
                    context.Notifications.Remove(p1);
                    context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
