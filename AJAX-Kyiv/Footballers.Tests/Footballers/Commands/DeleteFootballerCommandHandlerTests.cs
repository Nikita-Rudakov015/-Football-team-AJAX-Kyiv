using Footballers.Tests.Common;
using Footballers.Application.Footballers.Commands.DeleteFootballer;
using Footballers.Application.Footballers.Commands.CreateFootballer;
using Xunit;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Footballers.Application.Common.Exceptions;

namespace Footballers.Tests.Footballers.Commands
{
    public class DeleteFootballerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task DeleteFootballerCommandHandlerFailOnWrong()
        {
            //Arrange
            var handler = new DeleteFootballerCommandHandler(Context);
            var createHandler = new CreateFootballerCommandHandler(Context);
            var footballerId = await createHandler.Handle(
                new CreateFootballerCommand
                {
                    Name = "FootballerName",
                    UserId = FootballersContextFactory.UserAId
                }, CancellationToken.None);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(
                    new DeleteFootballerCommand
                    {
                        Id = footballerId,
                        UserId = FootballersContextFactory.UserAId
                    },
                    CancellationToken.None));
        }
        [Fact]
        public async Task DeleteFootballerCommandHandlerFailOnWrongUserId()
        {
            //Arrange
            var deleteHandler = new DeleteFootballerCommandHandler(Context);
            var createHandler = new CreateFootballerCommandHandler(Context);
            var footballerId = await createHandler.Handle(
                new CreateFootballerCommand
                {
                    Name = "FootballerName",
                    UserId = FootballersContextFactory.UserAId
                }, CancellationToken.None);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await deleteHandler.Handle(
                    new DeleteFootballerCommand()
                    {
                        Id = footballerId,
                        UserId = FootballersContextFactory.UserBId
                    }, CancellationToken.None));
        }
    }
}
