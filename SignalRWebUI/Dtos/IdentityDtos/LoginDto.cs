using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.IdentityDtos
{
	public class LoginDto
	{
		[JsonProperty("username")]
		public string Username { get; set; }

		[JsonProperty("password")]
		public string Password { get; set; }
	}
}
