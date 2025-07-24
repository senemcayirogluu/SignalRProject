using Microsoft.EntityFrameworkCore;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
	public class EfProductDal : GenericRepository<Product>, IProductDal
	{
		public EfProductDal(SignalRContext context) : base(context)
		{
		}

		public List<Product> GetProductsWithCategories()
		{
			var context = new SignalRContext();
			var values = context.Products.Include(p => p.Category).ToList();
			return values;
		}

		public int ProductCount()
		{
			using var context = new SignalRContext();
			return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			//return context.Products.Where(p => p.CategoryID == (context.Categories.Where(y => y.CategoryName == "İçecek").Select(x => x.CategoryID).FirstOrDefault())).Count();
			return context.Products.Count(p => p.Category.CategoryName == "İçecek");
		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			//return context.Products.Where(p => p.CategoryID == (context.Categories.Where(y => y.CategoryName == "Hamburger").Select(x => x.CategoryID).FirstOrDefault())).Count();
			return context.Products.Count(p => p.Category.CategoryName == "Hamburger");
		}

		public string ProductNameByMaxPrice()
		{
			using var context = new SignalRContext();
			return context.Products.OrderByDescending(p => p.Price).Select(p => p.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.OrderBy(p => p.Price).Select(p => p.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAverage()
		{
			using var context = new SignalRContext();
			return context.Products.Average(p => p.Price);
		}

		public decimal AvgProductPriceByHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(p => p.Category.CategoryName == "Hamburger").Select(p => p.Price).Average();
		}
	}
}
