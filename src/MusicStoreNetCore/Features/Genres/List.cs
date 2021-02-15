using MediatR;
using Microsoft.EntityFrameworkCore;
using MusicStoreNetCore.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MusicStoreNetCore.Features.Genres
{
    public class List
    {
        public record Query : IRequest<GenresEnvelope>;

        public class QueryHandler : IRequestHandler<Query, GenresEnvelope>
        {
            private readonly MusicStoreContext _context;

            public QueryHandler(MusicStoreContext context)
            {
                _context = context;
            }

            public async Task<GenresEnvelope> Handle(Query request, CancellationToken cancellationToken)
            {
                var genres = await _context.Genres
                    .OrderByDescending(x => x.GenreId)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);

                return new GenresEnvelope(genres);
            }
        }
    }
}
