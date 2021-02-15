using MusicStoreNetCore.Domain;
using System.Collections.Generic;

namespace MusicStoreNetCore.Features.Genres
{
    public record GenresEnvelope(List<Genre> Genres);
}
