using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class MenuController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public MenuController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/Product");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();

				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View(new List<ResultProductDto>());
		}

		[HttpPost]
		public async Task<IActionResult> AddBasket([FromBody] CreateBasketDto createBasketDto)
		{
			using var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBasketDto);
			var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7122/api/Baskets", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");

			}
			return Json(createBasketDto);
		}
	}
}
