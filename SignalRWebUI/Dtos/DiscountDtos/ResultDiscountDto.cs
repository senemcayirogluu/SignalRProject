using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.DiscountDto
{
	public class ResultDiscountDto
	{
		[JsonProperty("discountID")]
		public int DiscountID { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("amount")]
		public string Amount { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }
	}
}
