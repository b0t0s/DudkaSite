using System.Text.Json.Serialization;

namespace Site.Shared.Dto;

public class Orders
{
    [JsonPropertyName("id")] public int Id { get; set; }

    [JsonPropertyName("clientId")] public int ClientId { get; set; }

    [JsonPropertyName("type")] public int Type { get; set; }

    [JsonPropertyName("products")] public Dictionary<string, Products> Products { get; set; }

    [JsonPropertyName("comment")] public string Comment { get; set; }

    [JsonPropertyName("dateReservation")] public int DateReservation { get; set; }

    [JsonPropertyName("duration")] public int Duration { get; set; }

    [JsonPropertyName("guestCount")] public int GuestCount { get; set; }

    [JsonPropertyName("tableId")] public int TableId { get; set; }

    [JsonPropertyName("client")] public ClientDetail Client { get; set; }

    [JsonPropertyName("payment")] public PaymentDetails Payment { get; set; }

    [JsonPropertyName("sum")] public double Sum { get; set; }
}