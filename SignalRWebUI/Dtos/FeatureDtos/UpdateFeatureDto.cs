using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.FeatureDtos
{
	public class UpdateFeatureDto
	{
		[JsonProperty("featureID")]
		public int FeatureID { get; set; }

		[JsonProperty("title1")]
		public string Title1 { get; set; }

		[JsonProperty("description1")]
		public string Description1 { get; set; }

		[JsonProperty("title2")]
		public string Title2 { get; set; }

		[JsonProperty("description2")]
		public string Description2 { get; set; }

		[JsonProperty("title3")]
		public string Title3 { get; set; }

		[JsonProperty("description3")]
		public string Description3 { get; set; }
	}
}
