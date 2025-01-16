using Livestream.Application.Logic.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Livestream.Api.Controllers
{
    [ApiController]
    [Authorize]
    [Route("livestream-service/v1/livestream")]
    public class LivestreamController : ControllerBase
    {
        [HttpPost]
        [Authorize("manage:livestreams")]
        [Route("create")]
        public async Task<IActionResult> CreateLivestream([FromServices] IMediator mediator, [FromBody] CreateLivestreamCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }

}
