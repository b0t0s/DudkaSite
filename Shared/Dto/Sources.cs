using System.Text.Json.Serialization;

namespace Site.Shared.Dto;

public class Sources
{
    [JsonPropertyName("id")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Id { get; set; }

    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("price")] public string Price { get; set; }

    [JsonPropertyName("visible")] public string Visible { get; set; }
}