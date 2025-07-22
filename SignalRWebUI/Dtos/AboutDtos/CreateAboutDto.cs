using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.AboutDtos
{
	public class CreateAboutDto
	{
		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }
	}
}
