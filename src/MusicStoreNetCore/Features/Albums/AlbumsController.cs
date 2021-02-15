using MediatR;
using Microsoft.AspNetCore.Mvc;

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
    }
}
