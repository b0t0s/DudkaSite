using System.Text.Json.Serialization;

namespace Site.Shared.Dto;

public class Spots
{
    [JsonPropertyName("spot_id")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Id { get; set; }

    [JsonPropertyName("price")] public string Price { get; set; }

    [JsonPropertyName("profit")] public string Profit { get; set; }

    [JsonPropertyName("profit_netto")] public string ProfitNetto { get; set; }

    [JsonPropertyName("visible")] public string Visible { get; set; }
}