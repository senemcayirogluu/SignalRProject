using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.SocialMediaDto
{
	public class UpdateSocialMediaDto
	{

		[JsonProperty("socialMediaID")]
		public int SocialMediaID { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("url")]
		public string Url { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }
	}
}
