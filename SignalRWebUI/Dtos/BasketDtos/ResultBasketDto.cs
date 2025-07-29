using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.BasketDtos
{
	public class ResultBasketDto
	{
		[JsonProperty("basketID")]
		public int BasketID { get; set; }

		[JsonProperty("price")]
		public decimal Price { get; set; }

		[JsonProperty("count")]
		public decimal Count { get; set; }

		[JsonProperty("totalPrice")]
		public decimal TotalPrice { get; set; }

		[JsonProperty("productID")]
		public int ProductID { get; set; }

		[JsonProperty("menuTableID")]
		public int MenuTableID { get; set; }

		[JsonProperty("productName")]
		public string ProductName { get; set; }
	}
}
