using System.Text.Json.Serialization;

namespace Site.Shared.Dto;

public class Modifications
{
    [JsonPropertyName("modificator_id")]
    [JsonConverter(typeof(StringToNumericConverter))]
    public int Id { get; set; }

    [JsonPropertyName("modificator_name")] public string ModificatorName { get; set; }

    [JsonPropertyName("modificator_selfprice")]
    public string ModificatorSelfPrice { get; set; }

    [JsonPropertyName("order")] public string Order { get; set; }

    [JsonPropertyName("modificator_barcode")]
    public string ModificatorBarcode { get; set; }

    [JsonPropertyName("modificator_product_code")]
    public string ModificatorProductCode { get; set; }

    [JsonPropertyName("spots")] public List<Spots> Spots { get; set; }

    [JsonPropertyName("sources")] public List<Sources> Sources { get; set; }

    [JsonPropertyName("ingredient_id")] public string IngredientId { get; set; }

    [JsonPropertyName("fiscal_code")] public string FiscalCode { get; set; }
}