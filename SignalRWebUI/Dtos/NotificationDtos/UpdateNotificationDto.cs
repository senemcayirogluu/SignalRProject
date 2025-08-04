using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.NotificationDtos
{
	public class UpdateNotificationDto
	{
		[JsonProperty("notificationID")]
		public int NotificationID { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("icon")]
		public string Icon { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }
	}
}
