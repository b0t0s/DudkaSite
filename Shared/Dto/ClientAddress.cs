using System.Text.Json.Serialization;

namespace Site.Shared.Dto;

public class ClientAddress
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("delivery_zone_id")] public int? DeliveryZoneId { get; set; }

    [JsonPropertyName("country")] public string Country { get; set; }

    [JsonPropertyName("city")] public string City { get; set; }

    [JsonPropertyName("address1")] public string Address1 { get; set; }

    [JsonPropertyName("address2")] public string Address2 { get; set; }

    [JsonPropertyName("comment")] public string Comment { get; set; }

    [JsonPropertyName("lat")] public double? Latitude { get; set; }

    [JsonPropertyName("lng")] public double? Longitude { get; set; }

    [JsonPropertyName("zip_code")] public string ZipCode { get; set; }

    [JsonPropertyName("sort_order")] public int SortOrder { get; set; }
}