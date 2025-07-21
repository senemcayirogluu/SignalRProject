using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.CategoryDtos
{
	public class CreateCategoryDto
	{
		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }

	}
}
