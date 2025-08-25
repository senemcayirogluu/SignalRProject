using AutoMapper;
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
		private readonly IMapper _mapper;
		public NotificationController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult NotificationList()
		{
			var values = _mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll());
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
			createNotificationDto.Status = false;
			createNotificationDto.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			var value = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TAdd(value);
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
			return Ok(_mapper.Map<GetNotificationDto>(notification));
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var notification = _mapper.Map<Notification>(updateNotificationDto);
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
