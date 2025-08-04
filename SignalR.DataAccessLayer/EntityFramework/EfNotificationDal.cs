using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfNotificationDal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationDal(SignalRContext context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationByFalseStatus()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x => x.Status == false).ToList();
		}

		public void NotificationChangeStatusToFalse(int id)
		{
			using var context = new SignalRContext();
			var notification = context.Notifications.Find(id);
			notification.Status = false;
			context.SaveChanges();
		}

		public void NotificationChangeStatusToTrue(int id)
		{
			using var context = new SignalRContext();
			var notification = context.Notifications.Find(id);
			notification.Status = true;
			context.SaveChanges();
		}

		public int NotificationCountByFalseStatus()
		{
			using var context = new SignalRContext();
			return context.Notifications.Count(x => x.Status == false);
		}
	}
}
