﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MoneyCasesController : ControllerBase
	{
		private readonly IMoneyCaseService _moneyCaseService;

		public MoneyCasesController(IMoneyCaseService moneyCaseService)
		{
			_moneyCaseService = moneyCaseService;
		}

		[HttpGet("TotalMoneyCaseAmount")]
		public IActionResult TotalMoneyCaseAmount()
		{
			var totalAmount = _moneyCaseService.TTotalMoneyCaseAmount();
			return Ok(totalAmount);
		}
	}
}
