﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult DiscountList()
		{
			var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			_discountService.TAdd(new Discount()
			{
				Title = createDiscountDto.Title,
				Amount = createDiscountDto.Amount,
				Description = createDiscountDto.Description,
				ImageUrl = createDiscountDto.ImageUrl
			});
			return Ok("Discount başarıyla eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteDiscount(int id)
		{
			var value = _discountService.TGetById(id);
			_discountService.TDelete(value);
			return Ok("İndirim başarıyla silindi");
		}

		[HttpPut]
		public IActionResult UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			_discountService.TUpdate(new Discount()
			{
				DiscountID = updateDiscountDto.DiscountID,
				Title = updateDiscountDto.Title,
				Amount = updateDiscountDto.Amount,
				Description = updateDiscountDto.Description,
				ImageUrl = updateDiscountDto.ImageUrl
			});
			return Ok("İndirim başarıyla güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetDiscount(int id)
		{
			var value = _discountService.TGetById(id);
			return Ok(value);
		}
	}
}
