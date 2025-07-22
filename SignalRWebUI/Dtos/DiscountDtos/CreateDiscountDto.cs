using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.DiscountDto
{
	public class CreateDiscountDto
	{
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
