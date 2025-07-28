using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.ContactDtos
{
	public class CreateContactDto
	{
		[JsonProperty("location")]
		public string Location { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("mail")]
		public string Mail { get; set; }

		[JsonProperty("footerTitle")]
		public string FooterTitle { get; set; }

		[JsonProperty("footerDescription")]
		public string FooterDescription { get; set; }

		[JsonProperty("openDays")]
		public string OpenDays { get; set; }

		[JsonProperty("openDaysDescription")]
		public string OpenDaysDescription { get; set; }

		[JsonProperty("openHours")]
		public string OpenHours { get; set; }
	}
}
