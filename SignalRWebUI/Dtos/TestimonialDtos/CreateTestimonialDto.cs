using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.TestimonialDtos
{
	public class CreateTestimonialDto
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("comment")]
		public string Comment { get; set; }

		[JsonProperty("imageUrl")]
		public string ImageUrl { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }
	}
}
