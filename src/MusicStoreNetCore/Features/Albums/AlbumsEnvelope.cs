using MusicStoreNetCore.Domain;
using System.Collections.Generic;

namespace MusicStoreNetCore.Features.Albums
{
    public class AlbumsEnvelope
    {
        public List<Album> Albums { get; set; }
        public int AlbumsCount { get; set; }
    }
}
