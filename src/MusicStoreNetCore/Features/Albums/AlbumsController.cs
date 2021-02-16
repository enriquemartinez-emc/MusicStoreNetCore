using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace MusicStoreNetCore.Features.Albums
{
    [Route("api/genres")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AlbumsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{genreId}/albums")]
        public Task<AlbumsEnvelope> Get(int genreId, CancellationToken cancellationToken, bool isTopSellingAlBums = false)
        {
            return _mediator.Send(new List.Query(genreId, isTopSellingAlBums), cancellationToken);
        }
    }
}
