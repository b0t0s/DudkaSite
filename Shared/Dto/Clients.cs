using System.Text.Json.Serialization;

namespace Site.Shared.Dto;

public class Clients
{
    [JsonPropertyName("client_id")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Id { get; set; }

    [JsonPropertyName("firstname")] public string Firstname { get; set; }

    [JsonPropertyName("lastname")] public string Lastname { get; set; }

    [JsonPropertyName("patronymic")] public string Patronymic { get; set; }

    [JsonPropertyName("discount_per")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int DiscountPercentage { get; set; }

    [JsonPropertyName("bonus")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Bonus { get; set; }

    [JsonPropertyName("total_payed_sum")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int TotalPayedSum { get; set; }

    [JsonPropertyName("date_activale")] public string DateActivale { get; set; }

    [JsonPropertyName("phone")] public string Phone { get; set; }

    [JsonPropertyName("phone_number")] public string PhoneNumber { get; set; }

    [JsonPropertyName("email")] public string Email { get; set; }

    [JsonPropertyName("birthday")] public string Birthday { get; set; }

    [JsonPropertyName("card_number")] public string CardNumber { get; set; }

    [JsonPropertyName("client_sex")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int ClientSex { get; set; }

    [JsonPropertyName("country")] public string Country { get; set; }

    [JsonPropertyName("city")] public string City { get; set; }

    [JsonPropertyName("comment")] public string Comment { get; set; }

    [JsonPropertyName("address")] public string Address { get; set; }

    [JsonPropertyName("addresses")] public List<ClientAddress> Addresses { get; set; }

    [JsonPropertyName("client_groups_id")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int ClientGroupsId { get; set; }

    [JsonPropertyName("client_groups_name")]
    public string ClientGroupsName { get; set; }

    [JsonPropertyName("client_groups_discount")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int ClientGroupsDiscount { get; set; }

    [JsonPropertyName("loyalty_type")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int LoyaltyType { get; set; }

    [JsonPropertyName("birthday_bonus")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int BirthdayBonus { get; set; }

    [JsonPropertyName("delete")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Delete { get; set; }

    [JsonPropertyName("ewallet")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Ewallet { get; set; }
}