using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.MessageDtos
{
	public class UpdateMessageDto
	{
		[JsonProperty("messageID")]
		public int MessageID { get; set; }

		[JsonProperty("nameSurname")]
		public string NameSurname { get; set; }

		[JsonProperty("mail")]
		public string Mail { get; set; }

		[JsonProperty("phone")]
		public string Phone { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("messageContent")]
		public string MessageContent { get; set; }

		[JsonProperty("messageSendDate")]
		public DateTime MessageSendDate { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }
	}
}
