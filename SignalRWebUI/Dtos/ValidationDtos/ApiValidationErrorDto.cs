using Newtonsoft.Json;

namespace SignalRWebUI.Dtos.ValidationDtos
{
	public class ApiValidationErrorDto
	{
		[JsonProperty("propertyName")]
		public string PropertyName { get; set; }

		[JsonProperty("errorMessage")]
		public string ErrorMessage { get; set; }
	}
}
