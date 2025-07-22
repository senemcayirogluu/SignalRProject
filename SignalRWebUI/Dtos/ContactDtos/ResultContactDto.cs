using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.ContactDtos
{
	public class ResultContactDto
	{
		[JsonProperty("contactID")]
		public int ContactID { get; set; }

		[JsonProperty("location")]
		public string Location { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("mail")]
		public string Mail { get; set; }

		[JsonProperty("footerDescription")]
		public string FooterDescription { get; set; }
	}
}
