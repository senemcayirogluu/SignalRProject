﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediaController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SocialMediaList()
		{
			var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
			return Ok(values);
		}

		[HttpPost]
		public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
		{
			_socialMediaService.TAdd(new SocialMedia()
			{
				Title = createSocialMediaDto.Title,
				Url = createSocialMediaDto.Url,
				Icon = createSocialMediaDto.Icon
			});
			return Ok("Sosyal medya bilgileri başarıyla eklendi");
		}

		[HttpDelete]
		public IActionResult DeleteSocialMedia(int id)
		{
			var value = _socialMediaService.TGetById(id);
			_socialMediaService.TDelete(value);
			return Ok("Sosyal medya bilgileri başarıyla silindi");
		}

		[HttpPut]
		public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
		{
			_socialMediaService.TUpdate(new SocialMedia()
			{
				SocialMediaID = updateSocialMediaDto.SocialMediaID,
				Title = updateSocialMediaDto.Title,
				Url = updateSocialMediaDto.Url,
				Icon = updateSocialMediaDto.Icon
			});
			return Ok("Sosyal medya bilgileri başarıyla güncellendi");
		}

		[HttpGet("GetSocialMedia")]
		public IActionResult GetSocialMedia(int id)
		{
			var value = _socialMediaService.TGetById(id);
			return Ok(value);
		}
	}
}
