using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.CategoryDtos
{
	public class UpdateCategoryDto
	{
		[JsonProperty("categoryID")]
		public int CategoryID { get; set; }

		[JsonProperty("categoryName")]
		public string CategoryName { get; set; }

		[JsonProperty("status")]
		public bool Status { get; set; }
	}
}
