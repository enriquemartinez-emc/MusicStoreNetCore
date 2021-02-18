using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStoreNetCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;

namespace MusicStoreNetCore.Features.Albums
{
    public class Details
    {
        public record Query(int AlbumId) : IRequest<AlbumEnvelope>;

        public class QueryHandler : IRequestHandler<Query, AlbumEnvelope>
        {
            private readonly MusicStoreContext _context;

            public QueryHandler(MusicStoreContext context) => _context = context;

            public async Task<AlbumEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var album = await _context.Albums
                    .Include(x => x.Genre)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.AlbumId == request.AlbumId, cancellationToken);

                return new AlbumEnvelope(album);
            }
        }
    }
}
