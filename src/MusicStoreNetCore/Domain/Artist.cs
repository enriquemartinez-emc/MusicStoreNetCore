using System.Text.Json.Serialization;

namespace MusicStoreNetCore.Domain
{
    public class Artist
    {
        [JsonIgnore]
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}
