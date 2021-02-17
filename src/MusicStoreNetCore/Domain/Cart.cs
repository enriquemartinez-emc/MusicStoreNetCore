using System;
using System.Text.Json.Serialization;

namespace MusicStoreNetCore.Domain
{
    public class Cart
    {
        [JsonIgnore]
        public int CartId { get; set; }
        public Guid UniqueId { get; set; }
        public int Count { get; set; }
        public Album Album { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
