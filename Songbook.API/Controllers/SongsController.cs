using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Songbook.Domain.Requests.v1;
using Songbook.Infrastructure.MediatR.v1.Commands;

namespace Songbook.API.Controllers
{
    [Route("api/v{version:apiVersion}/songs")]
    [ApiVersion("1.0")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class SongsController : ControllerBase
	{
        private readonly IMediator _mediator;

        public SongsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add([FromBody] AddEditSongRequest request)
        {
            var result = await _mediator.Send(new AddSongCommand(request));
            return Ok(result);
        }
    }
}

