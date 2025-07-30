using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketsController : ControllerBase
	{
		private readonly IBasketService _basketService;
		private readonly IProductService _productService;

		public BasketsController(IBasketService basketService, IProductService productService)
		{
			_basketService = basketService;
			_productService = productService;
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

		[HttpPost]
		public IActionResult CreateBasket(CreateBasketDto createBasketDto)
		{
			var product = _productService.TGetById(createBasketDto.ProductID);
			_basketService.TAdd(new Basket()
			{
				Price = product.Price,
				Count = 1,
				TotalPrice = 0,
				ProductID = createBasketDto.ProductID,
				MenuTableID = 4,
			});
			return Ok();

			//using var context = new SignalRContext();
			//_basketService.TAdd(new Basket()
			//{
			//	Price = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault(),
			//	Count = 1,
			//	TotalPrice = 0,
			//	ProductID = createBasketDto.ProductID,
			//	MenuTableID = 4,
			//});
			//return Ok();
		}
	}

}
