
using Livestream.Api.Controllers;
using Livestream.Application.Logic.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Xunit;

namespace Livestream.Api.Test.ControllerTests
{
    public class LivestreamContsrollerTests
    {
        [Fact]
        public async Task CreateLivestream_ReturnsOkResult_WhenCommandIsHandledSuccessfully()
        {
            // Arrange
            var mediator = Substitute.For<IMediator>();
            var command = new CreateLivestreamCommand("tst", 1); // Use appropriate constructor or initialization for the command
            var controller = new LivestreamController();

            // Act
            var result = await controller.CreateLivestream(mediator, command);

            // Assert
            await mediator.Received(1).Send(command);
            var okResult = Assert.IsType<OkResult>(result);
        }

    }
}