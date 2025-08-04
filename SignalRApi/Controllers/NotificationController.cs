using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		[HttpGet]
		public IActionResult NotificationList()
		{
			var values = _notificationService.TGetListAll();
			return Ok(values);
		}

		[HttpGet("NotificationCountByFalseStatus")]
		public IActionResult NotificationCountByFalseStatus()
		{
			var values = _notificationService.TNotificationCountByFalseStatus();
			return Ok(values);
		}

		[HttpGet("GetAllNotificationByFalseStatus")]
		public IActionResult GetAllNotificationByFalseStatus()
		{
			var values = _notificationService.TGetAllNotificationByFalseStatus();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			Notification notification = new Notification()
			{
				Type = createNotificationDto.Type,
				Icon = createNotificationDto.Icon,
				Description = createNotificationDto.Description,
				Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				Status = false
			};
			_notificationService.TAdd(notification);
			return Ok("Bildirim başarılı bir şekilde eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var notification = _notificationService.TGetById(id);
			_notificationService.TDelete(notification);
			return Ok("Bildirim başarılı bir şekilde silindi");
		}

		[HttpGet("{id}")]
		public IActionResult GetNotificationById(int id)
		{
			var notification = _notificationService.TGetById(id);
			return Ok(notification);
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationID = updateNotificationDto.NotificationID,
				Type = updateNotificationDto.Type,
				Icon = updateNotificationDto.Icon,
				Description = updateNotificationDto.Description,
				Date = updateNotificationDto.Date,
				Status = updateNotificationDto.Status,
			};
			_notificationService.TUpdate(notification);
			return Ok("Bildirim başarılı bir şekilde güncellendi");
		}

		[HttpGet("NotificationChangeStatusToFalse/{id}")]
		public IActionResult NotificationChangeStatusToFalse(int id)
		{
			_notificationService.TNotificationChangeStatusToFalse(id);
			return Ok("Bildirim durumu false olarak güncellendi");
		}

		[HttpGet("NotificationChangeStatusToTrue/{id}")]
		public IActionResult NotificationChangeStatusToTrue(int id)
		{
			_notificationService.TNotificationChangeStatusToTrue(id);
			return Ok("Bildirim durumu true olarak güncellendi");
		}
	}
}
