using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.RapidApiDtos;

namespace SignalRWebUI.Controllers
{
	public class FoodApiController : Controller
	{
		public async Task<IActionResult> Index()
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=60&tags=under_30_minutes"),
				Headers =
	{
		{ "x-rapidapi-key", "76755a7d0fmshc7882dd7ba99249p18ee99jsn3e5a94aea86d" },
		{ "x-rapidapi-host", "tasty.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var root = JsonConvert.DeserializeObject<RootFoodApi>(body);
				var values = root.Results.ToList();
				return View(values);
			}
		}
	}
}
