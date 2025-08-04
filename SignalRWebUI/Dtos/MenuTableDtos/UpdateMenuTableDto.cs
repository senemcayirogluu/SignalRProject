using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.MenuTableDtos
{
	public class UpdateMenuTableDto
	{
		[JsonProperty("menuTableID")]
		public int MenuTableID { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }
	}
}
