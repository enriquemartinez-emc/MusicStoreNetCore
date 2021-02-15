using System;
using System.Text.Json.Serialization;

namespace MusicStoreNetCore.Domain
{
    public class CartItem
    {
        [JsonIgnore]
        public int CartItemId { get; set; }
        public string CartId { get; set; }
        public int Count { get; set; }
        public Album Album { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
