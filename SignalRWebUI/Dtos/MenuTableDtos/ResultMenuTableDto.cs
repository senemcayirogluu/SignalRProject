using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.MenuTableDtos
{
	public class ResultMenuTableDto
	{
		[JsonProperty("menuTableID")]
		public int MenuTableID { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }
	}
}
