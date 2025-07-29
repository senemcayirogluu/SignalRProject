using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketsController : ControllerBase
	{
		private readonly IBasketService _basketService;

		public BasketsController(IBasketService basketService)
		{
			_basketService = basketService;
		}

		[HttpGet]
		public IActionResult GetBasketByMenuTableNumber(int id)
		{
			var values = _basketService.TGetBasketByMenuTableNumber(id);
			return Ok(values);
		}

		[HttpGet("BasketListByMenuTableWithProductName")]
		public IActionResult BasketListByMenuTableWithProductName(int id)
		{
			using var context = new SignalRContext();
			var values = context.Baskets.Include(x => x.Product).Where(t => t.MenuTableID == id).Select(z => new ResultBasketListWithProducts
			{
				BasketID = z.BasketID,
				Price = z.Price,
				Count = z.Count,
				TotalPrice = z.TotalPrice,
				ProductID = z.ProductID,
				MenuTableID = z.MenuTableID,
				ProductName = z.Product.ProductName
			}).ToList();

			return Ok(values);
		}

	}

}
