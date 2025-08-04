using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.NotificationDtos
{
	public class CreateNotificationDto
	{

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }
	}
}
