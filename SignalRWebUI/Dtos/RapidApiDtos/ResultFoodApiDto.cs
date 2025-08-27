using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.RapidApiDtos
{
	public class RootFoodApi
	{
		public List<ResultFoodApiDto> Results { get; set; }
	}
	public class ResultFoodApiDto
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("video_url")]
		public string VideoUrl { get; set; }

		[JsonProperty("total_time_minutes")]
		public int TotalTimeMinutes { get; set; }

		[JsonProperty("thumbnail_url")]
		public string ThumbnailUrl { get; set; }
	}
}
