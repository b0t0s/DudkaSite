using System.Text.Json.Serialization;

namespace Site.Shared.Dto;

public class ClientDetail
{
    [JsonPropertyName("firstName")] public string FirstName { get; set; }

    // ... (other properties are similar to the one above)

    [JsonPropertyName("clientGroupsId")] public int ClientGroupsId { get; set; }
}