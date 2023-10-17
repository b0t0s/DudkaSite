using Newtonsoft.Json;

namespace Site.Shared.Dto;

public class Supply
{
    [JsonProperty("supply_id")]
    public int SupplyId { get; set; }

    [JsonProperty("storage_id")]
    public int StorageId { get; set; }

    [JsonProperty("supplier_id")]
    public int SupplierId { get; set; }

    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("supply_sum")]
    public decimal SupplySum { get; set; }

    [JsonProperty("supply_sum_netto")]
    public decimal SupplySumNetto { get; set; }

    [JsonProperty("supply_comment")]
    public string SupplyComment { get; set; }

    [JsonProperty("storage_name")]
    public string StorageName { get; set; }

    [JsonProperty("supplier_name")]
    public string SupplierName { get; set; }

    [JsonProperty("delete")]
    public bool IsDeleted { get; set; }

    [JsonProperty("account_id")]
    public int? AccountId { get; set; }
}