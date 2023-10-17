using System.Text.Json.Serialization;

namespace Site.Shared.Dto;

public class PaymentDetails
{
    [JsonPropertyName("id")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Id { get; set; }

    [JsonPropertyName("incomingOrderId")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int IncomingOrderId { get; set; }

    [JsonPropertyName("type")] public int Type { get; set; }

    [JsonPropertyName("sum")] public double Sum { get; set; }

    [JsonPropertyName("createdAt")] public int CreatedAt { get; set; }
}