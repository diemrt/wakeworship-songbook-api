using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Songbook.Domain.Requests.v1;
using Songbook.Infrastructure.MediatR.v1.Commands;
using Songbook.Infrastructure.MediatR.v1.Queries.Songs;

namespace Songbook.API.Controllers
{
    [Authorize]
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllSongsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _mediator.Send(new GetSongByIdQuery(id));
            return Ok(result);
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

