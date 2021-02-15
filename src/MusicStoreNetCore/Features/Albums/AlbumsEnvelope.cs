using MusicStoreNetCore.Domain;
using System.Collections.Generic;

namespace MusicStoreNetCore.Features.Albums
{
    public record AlbumsEnvelope(List<Album> Albums);
}
