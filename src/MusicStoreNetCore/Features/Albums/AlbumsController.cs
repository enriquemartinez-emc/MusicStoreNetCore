using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace MusicStoreNetCore.Features.Albums
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public Task<AlbumsEnvelope> Get([FromQuery] int? genreId, [FromQuery] int? limit, [FromQuery] int? offset, CancellationToken cancellationToken, bool isTopSelling = false)
        {
            return _mediator.Send(new List.Query(genreId, limit, offset, isTopSelling), cancellationToken);
        }

        [HttpGet("{albumId}")]
        public Task<AlbumEnvelope> Get(int albumId, CancellationToken cancellationToken)
        {
            return _mediator.Send(new Details.Query(albumId), cancellationToken);
        }
    }
}
