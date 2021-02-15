using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicStoreNetCore.Domain
{
    public class Album
    {
        [JsonIgnore]
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public Genre Genre { get; set; }
        public Artist Artist { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public DateTime Created { get; set; }
    }
}
