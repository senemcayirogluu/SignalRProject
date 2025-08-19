using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.MailDtos
{
	public class CreateMailDto
	{
		[JsonProperty("receiverMail")]
		public string ReceiverMail { get; set; }

		[JsonProperty("subject")]
		public string Subject { get; set; }

		[JsonProperty("body")]
		public string Body { get; set; }
	}
}
