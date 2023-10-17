using Newtonsoft.Json;

namespace Site.Shared.Dto;

public class Category
{
    [JsonProperty("category_id")] public int CategoryId { get; set; }

    [JsonProperty("category_name")] public string CategoryName { get; set; }

    [JsonProperty("category_photo")] public string CategoryPhoto { get; set; }

    [JsonProperty("category_photo_origin")]
    public string CategoryPhotoOrigin { get; set; }

    [JsonProperty("parent_category")] public string ParentCategory { get; set; }

    [JsonProperty("category_color")] public string CategoryColor { get; set; }

    [JsonProperty("category_hidden")] public string CategoryHidden { get; set; }

    [JsonProperty("sort_order")] public string SortOrder { get; set; }

    [JsonProperty("fiscal")] public string Fiscal { get; set; }

    [JsonProperty("nodiscount")] public string NoDiscount { get; set; }

    [JsonProperty("tax_id")] public string TaxId { get; set; }

    [JsonProperty("left")] public string Left { get; set; }

    [JsonProperty("right")] public string Right { get; set; }

    [JsonProperty("level")] public string Level { get; set; }

    [JsonProperty("category_tag")] public string CategoryTag { get; set; }

    [JsonProperty("visible")] public List<Visibility> Visible { get; set; }
}

public class Visibility
{
    [JsonProperty("spot_id")] public int SpotId { get; set; }

    [JsonProperty("visible")] public int IsVisible { get; set; }
}