using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Songbook.Domain.Exceptions.v1.Common;
using Songbook.Domain.Response.v1.Common;
using Songbook.Infrastructure.MediatR.v1.Queries.Users;

namespace Songbook.API.Controllers
{
    [Authorize]
    [ApiController, Route("api/v{version:apiVersion}/users")]
    [ApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ApiErrors))]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByUid([FromQuery] string uid)
        {
            var result = await _mediator.Send(new GetUserByUidQuery(uid));
            return Ok(result);
        }

    }
}
