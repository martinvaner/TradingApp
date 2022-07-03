using System.Text.Json.Serialization;

namespace Downloader.Infrastructure.DTOs
{
	public class PriceDTO
	{
		[JsonPropertyName("close")]
		public double Close { get; set; }
	}
}
