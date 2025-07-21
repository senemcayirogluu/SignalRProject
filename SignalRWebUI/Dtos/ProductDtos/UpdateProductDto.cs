using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.ProductDtos
{
	public class UpdateProductDto
	{
		[JsonProperty("productID")]
		public int ProductID { get; set; }

		[JsonProperty("productName")]
		public string ProductName { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("price")]
		public decimal Price { get; set; }

		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }

		[JsonProperty("productStatus")]
		public bool ProductStatus { get; set; }

		[JsonProperty("categoryID")]
		public int CategoryID { get; set; }
	}
}
