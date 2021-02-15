using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStoreNetCore.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicStoreNetCore.Features.Albums
{
    public class List
    {
        public record Query(int GenreId, bool IsTopSellingQuery = false) : IRequest<AlbumsEnvelope>;

        public class QueryHandler : IRequestHandler<Query, AlbumsEnvelope>
        {
            private readonly MusicStoreContext _context;

            public QueryHandler(MusicStoreContext context)
            {
                _context = context;
            }

            public async Task<AlbumsEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.IsTopSellingQuery)
                {
                    var topSellingAlbums = await _context.Albums
                            .OrderByDescending(a => a.OrderDetails.Count)
                            .Take(6)
                            .AsNoTracking()
                            .ToListAsync(cancellationToken);

                    return new AlbumsEnvelope(topSellingAlbums);
                }

                var genres = await _context.Genres
                            .Include(x => x.Albums)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(x => x.GenreId == request.GenreId, cancellationToken);

                return new AlbumsEnvelope(genres.Albums);
            }
        }

    }
}
