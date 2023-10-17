using Newtonsoft.Json;

namespace Site.Shared.Dto;

public class Storages
{
    [JsonProperty("storage_id")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Id { get; set; }

    [JsonProperty("storage_name")] public string StorageName { get; set; }

    [JsonProperty("storage_adress")] public string StorageAddress { get; set; }

    [JsonProperty("delete")] public string Delete { get; set; }
}