using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicStoreNetCore.Domain
{
    public class Genre
    {
        [JsonIgnore]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}
