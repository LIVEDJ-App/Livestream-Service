using Livestream.Application.Logic.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Livestream.Api.Controllers
{
    [ApiController]
    [Route("livestream-service/v1/livestream")]
    public class LivestreamController : ControllerBase
    {
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateLivestream([FromServices] IMediator mediator, [FromBody] CreateLivestreamCommand command)
        {
            await mediator.Send(command);
            return Ok();
        }
    }

}
