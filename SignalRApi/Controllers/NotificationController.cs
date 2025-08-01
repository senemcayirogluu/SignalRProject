﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

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
	}
}
