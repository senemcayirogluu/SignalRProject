using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.SocialMediaDto
{
	public class CreateSocialMediaDto
	{
		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }
	}
}
