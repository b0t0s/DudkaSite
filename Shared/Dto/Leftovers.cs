using Newtonsoft.Json;

namespace Site.Shared.Dto;

public class Leftovers
{
    [JsonProperty("ingredient_id")] public int Id { get; set; }

    [JsonProperty("ingredient_name")] public string ItemName { get; set; }

    [JsonProperty("ingredient_left")] public double ItemsLeft { get; set; } // Changed to double

    [JsonProperty("limit_value")] public string LimitValue { get; set; }

    [JsonProperty("ingredient_unit")] public string ItemUnit { get; set; }

    [JsonProperty("ingredients_type")] public string ItemType { get; set; }

    [JsonProperty("storage_ingredient_sum")]
    public string StorageItemSum { get; set; }

    [JsonProperty("prime_cost")] public double PrimeCost { get; set; }

    [JsonProperty("prime_cost_netto")] public string PrimeCostNetto { get; set; }

    [JsonProperty("hidden")] public string Hidden { get; set; }
}