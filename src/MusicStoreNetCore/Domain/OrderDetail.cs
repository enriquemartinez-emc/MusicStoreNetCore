using System.Text.Json.Serialization;

namespace MusicStoreNetCore.Domain
{
    public class OrderDetail
    {
        [JsonIgnore]
        public int OrderDetailId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Album Album { get; set; }
        public Order Order { get; set; }
    }
}
