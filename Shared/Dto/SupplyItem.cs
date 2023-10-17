namespace Site.Shared.Dto;

using Newtonsoft.Json;

public class SupplyItem
{
    [JsonProperty("ingredient_id")]
    public int ItemId { get; set; }

    [JsonProperty("supply_ingredient_num")]
    public decimal SupplyItemNum { get; set; }

    [JsonProperty("supply_ingredient_sum")]
    public decimal SupplyItemSum { get; set; }

    [JsonProperty("supply_ingredient_sum_netto")]
    public decimal SupplyItemSumNetto { get; set; }

    [JsonProperty("ingredient_name")]
    public string ItemName { get; set; }

    [JsonProperty("ingredient_unit")]
    public string ItemUnit { get; set; }

    [JsonProperty("tax_id")]
    public int TaxId { get; set; }
}