using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.IdentityDtos
{
	public class RegisterDto
	{
		[JsonProperty("name")]
		public string Name{ get; set; }

		[JsonProperty("surname")]
		public string Surname{ get; set; }

		[JsonProperty("username")]
		public string Username{ get; set; }

		[JsonProperty("mail")]
		public string Mail{ get; set; }

		[JsonProperty("password")]
		public string Password{ get; set; }
	}
}
