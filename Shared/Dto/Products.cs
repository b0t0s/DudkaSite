using Newtonsoft.Json;

namespace Site.Shared.Dto;

public class Products
{
    [JsonProperty("product_id")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Id { get; set; }

    [JsonProperty("barcode")] public string Barcode { get; set; }

    [JsonProperty("category_name")] public string CategoryName { get; set; }

    [JsonProperty("unit")] public string? Unit { get; set; }

    [JsonProperty("cost")] public string? Cost { get; set; }

    [JsonProperty("cost_netto")] public string? CostNetto { get; set; }

    [JsonProperty("fiscal")] public string? Fiscal { get; set; }

    [JsonProperty("menu_category_id")] public string? MenuCategoryId { get; set; }

    [JsonProperty("workshop")] public string? Workshop { get; set; }

    [JsonProperty("nodiscount")] public string? NoDiscount { get; set; }

    [JsonProperty("photo")] public string? Photo { get; set; }

    [JsonProperty("photo_origin")] public string? PhotoOrigin { get; set; }

    [JsonProperty("product_code")] public string? ProductCode { get; set; }

    [JsonProperty("product_name")] public string? ProductName { get; set; }

    [JsonProperty("sort_order")] public string? SortOrder { get; set; }

    [JsonProperty("tax_id")] public string? TaxId { get; set; }

    [JsonProperty("product_tax_id")] public string? ProductTaxId { get; set; }

    [JsonProperty("type")] public string? Type { get; set; }

    [JsonProperty("weight_flag")] public string? WeightFlag { get; set; }

    [JsonProperty("color")] public string? Color { get; set; }

    [JsonProperty("ingredient_id")] public string? IngredientId { get; set; }

    [JsonProperty("cooking_time")] public string? CookingTime { get; set; }

    [JsonProperty("fiscal_code")] public string? FiscalCode { get; set; }

    [JsonProperty("modifications")] public List<Modifications> Modifications { get; set; }

    [JsonProperty("out")] public int? Out { get; set; }
}