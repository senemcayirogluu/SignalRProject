using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.TestimonialDtos
{
	public class GetTestimonialDto
	{
		[JsonProperty("testimonialID")]
		public int TestimonialID { get; set; }

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
