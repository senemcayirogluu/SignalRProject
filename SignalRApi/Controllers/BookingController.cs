using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _bookingService.TGetListAll();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult BookingAdd(CreateBookingDto createBookingDto)
		{
			Booking booking = new Booking()
			{
				Name = createBookingDto.Name,
				Phone = createBookingDto.Phone,
				Mail = createBookingDto.Mail,
				PersonCount = createBookingDto.PersonCount,
				Date = createBookingDto.Date
			};
			_bookingService.TAdd(booking);
			return Ok("Rezervasyon başarılı şekilde yapıldı");
		}

		[HttpDelete]
		public IActionResult Delete(int id)
		{
			var value = _bookingService.TGetById(id);
			_bookingService.TDelete(value);
			return Ok("Rezervasyon başarılı şekilde silindi");
		}

		[HttpPut]
		public IActionResult Update(UpdateBookingDto updateBookingDto)
		{
			Booking booking = new Booking()
			{
				BookingID = updateBookingDto.BookingID,
				Name = updateBookingDto.Name,
				Phone = updateBookingDto.Phone,
				Mail = updateBookingDto.Mail,
				PersonCount = updateBookingDto.PersonCount,
				Date = updateBookingDto.Date
			};
			_bookingService.TUpdate(booking);
			return Ok("Rezervasyon başarılı şekilde güncellendi");
		}

		[HttpGet("GetBooking")]
		public IActionResult GetBooking(int id)
		{
			var value = _bookingService.TGetById(id);
			return Ok(value);
		}
	}
}
