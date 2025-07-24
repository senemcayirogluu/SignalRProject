using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(values);
		}

		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory() 
		{
			var context = new SignalRContext();
			var values = context.Products.Include(p => p.Category).Select(y => new ResultProductWithCategory
			{
				ProductID = y.ProductID,
				ProductName = y.ProductName,
				Description = y.Description,
				Price = y.Price,
				ImageUrl = y.ImageUrl,
				ProductStatus = y.ProductStatus,
				CategoryName = y.Category.CategoryName
			});
			return Ok(values.ToList());
		}

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			var count = _productService.TProductCount();
			return Ok(count);
		}

		[HttpGet("ProductCountByCategoryNameHamburger")]
		public IActionResult ProductCountByCategoryNameHamburger()
		{
			var count = _productService.TProductCountByCategoryNameHamburger();
			return Ok(count);
		}

		[HttpGet("ProductCountByCategoryNameDrink")]
		public IActionResult ProductCountByCategoryNameDrink()
		{
			var count = _productService.TProductCountByCategoryNameDrink();
			return Ok(count);
		}

		[HttpGet("ProductPriceAverage")]
		public IActionResult ProductPriceAverage()
		{
			var average = _productService.TProductPriceAverage();
			return Ok(average);
		}

		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			var name = _productService.TProductNameByMaxPrice();
			return Ok(name);
		}

		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			var name = _productService.TProductNameByMinPrice();
			return Ok(name);
		}

		[HttpGet("AvgProductPriceByHamburger")]
		public IActionResult AvgProductPriceByHamburger()
		{
			var average = _productService.TAvgProductPriceByHamburger();
			return Ok(average);
		}

		[HttpPost]
		public IActionResult CreateProduct(CreateProductDto createProductDto)
		{
			_productService.TAdd(new Product()
			{
				ProductName = createProductDto.ProductName,
				Description = createProductDto.Description,
				Price = createProductDto.Price,	
				ImageUrl = createProductDto.ImageUrl,
				ProductStatus = createProductDto.ProductStatus,
				CategoryID = createProductDto.CategoryID
			});
			return Ok("Ürün başarıyla eklendi");
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteProduct(int id)
		{
			var value = _productService.TGetById(id);
			_productService.TDelete(value);
			return Ok("Ürün başarıyla silindi");
		}

		[HttpPut]
		public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
		{
			_productService.TUpdate(new Product()
			{
				ProductID = updateProductDto.ProductID,
				ProductName = updateProductDto.ProductName,
				Description = updateProductDto.Description,
				Price = updateProductDto.Price,
				ImageUrl = updateProductDto.ImageUrl,
				ProductStatus = updateProductDto.ProductStatus,
				CategoryID = updateProductDto.CategoryID
			});
			return Ok("Ürün başarıyla güncellendi");
		}

		[HttpGet("{id}")]
		public IActionResult GetProduct(int id)
		{
			var value = _productService.TGetById(id);
			return Ok(value);
		}
	}
}
