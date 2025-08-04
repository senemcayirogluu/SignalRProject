using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.MenuTableDtos
{
	public class CreateMenuTableDto
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }
	}
}
