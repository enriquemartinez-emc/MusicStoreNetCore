using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStoreNetCore.Domain;
using MusicStoreNetCore.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicStoreNetCore.Features.Albums
{
    public class List
    {
        public record Query(int? GenreId, int? Limit, int? Offset, bool IsTopSelling = false) : IRequest<AlbumsEnvelope>;

        public class QueryHandler : IRequestHandler<Query, AlbumsEnvelope>
        {
            private readonly MusicStoreContext _context;

            public QueryHandler(MusicStoreContext context) => _context = context;

            public async Task<AlbumsEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var queryable = _context.Albums
                    .Include(x => x.Genre)
                    .Include(x => x.OrderDetails)
                    .AsNoTracking();

                if (request.IsTopSelling)
                {
                    var topSellingAlbums = await queryable
                            .OrderByDescending(x => x.OrderDetails.Count)
                            .Take(3)
                            .ToListAsync(cancellationToken);

                    return new AlbumsEnvelope
                    {
                        Albums = topSellingAlbums,
                        AlbumsCount = 6
                    };
                }

                if (request.GenreId != null)
                {
                    var genre = await _context.Genres.FirstOrDefaultAsync(x => x.GenreId == request.GenreId, cancellationToken);
                    if (genre == null)
                    {
                        return new AlbumsEnvelope();
                    }
                    queryable = queryable.Where(x => x.Genre == genre);
                }

                var albums = await queryable
                    .OrderByDescending(x => x.AlbumId)
                    .Skip(request.Offset ?? 0)
                    .Take(request.Limit ?? 20)
                    .ToListAsync(cancellationToken);

                return new AlbumsEnvelope
                {
                    Albums = albums,
                    AlbumsCount = queryable.Count()
                };
            }
        }

    }
}
