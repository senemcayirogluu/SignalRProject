using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Dtos.ValidationDtos;
using System.Net.Http;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class BookATableController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookATableController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			HttpClient client = _httpClientFactory.CreateClient();
			HttpResponseMessage response = await client.GetAsync("https://localhost:7122/api/Contact");
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			JArray item = JArray.Parse(responseBody);
			string value = item[0]["location"].ToString();
			ViewBag.location = value;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateBookingDto createBookingDto)
		{
			HttpClient client2 = _httpClientFactory.CreateClient();
			HttpResponseMessage response = await client2.GetAsync("https://localhost:7122/api/Contact");
			response.EnsureSuccessStatusCode();
			string responseBody = await response.Content.ReadAsStringAsync();
			JArray item = JArray.Parse(responseBody);
			string value = item[0]["location"].ToString();
			ViewBag.location = value;

			createBookingDto.Description = "Rezervasyon";

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBookingDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7122/api/Booking", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}
			else
			{
				var errorContent = await responseMessage.Content.ReadAsStringAsync();
				var errors = JsonConvert.DeserializeObject<List<ApiValidationErrorDto>>(errorContent);

				if (errors != null)
				{
					foreach (var error in errors)
					{
						ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
					}
				}

				return View(createBookingDto);
			}
		}
	}
}
