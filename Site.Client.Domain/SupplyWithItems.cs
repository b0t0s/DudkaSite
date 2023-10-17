using Site.Shared.Dto;

namespace Site.Client.Domain
{
    public class SupplyWithItems
    {
        public Supply Supply { get; set; }
        public List<SupplyItem> SupplyItems { get; set; }
    }
}