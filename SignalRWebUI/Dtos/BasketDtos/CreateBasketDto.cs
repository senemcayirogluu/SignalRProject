using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.BasketDtos
{
	public class CreateBasketDto
	{
		[JsonProperty("productID")]
		public int ProductID { get; set; }

		[JsonProperty("menuTableID")]
		public int MenuTableID { get; set; }

	}
}
