using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
	public interface INotificationDal:IGenericDal<Notification>
	{
		public int NotificationCountByFalseStatus();
		public List<Notification> GetAllNotificationByFalseStatus();
		void NotificationChangeStatusToTrue(int id);
		void NotificationChangeStatusToFalse(int id);
	}
}
