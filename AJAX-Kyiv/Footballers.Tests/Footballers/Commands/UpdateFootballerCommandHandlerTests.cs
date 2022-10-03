using Footballers.Tests.Common;
using Footballers.Application.Footballers.Commands.UpdateFootballer;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Footballers.Application.Common.Exceptions;
using System;

namespace Footballers.Tests.Footballers.Commands
{
    public class UpdateFootballerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task UpdateFootballerCommandHandlerSuccess()
        {
            //Arrange
            var handler = new UpdateFootballerCommandHandler(Context);
            var updatedName = "new name";
            //Act
            await handler.Handle(new UpdateFootballerCommand
            {
                Id = FootballersContextFactory.FootballerIdForUpdate,
                UserId = FootballersContextFactory.UserBId,
                Name = updatedName,
            }, CancellationToken.None);
            //Assert
            Assert.NotNull(
                await Context.Footballers.SingleOrDefaultAsync(footballer => 
                footballer.Id == FootballersContextFactory.FootballerIdForUpdate &&
                footballer.Name == updatedName));
        }

        [Fact]
        public async Task UpdateFootballerCommandHandlerFailOnWrongId()
        {
            //Arrange
            var handler = new UpdateFootballerCommandHandler(Context);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
                await handler.Handle(new UpdateFootballerCommand
                {
                    Id = FootballersContextFactory.FootballerIdForUpdate,
                    UserId = FootballersContextFactory.UserAId
                }, CancellationToken.None)) ;
        }

        [Fact]
        public async Task UpdateFootballerCommandHandlerFailOnWrongUserId()
        {
            //Arrange
            var handler = new UpdateFootballerCommandHandler(Context);
            //Act
            //Assert
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await handler.Handle(new UpdateFootballerCommand
                {
                    Id = FootballersContextFactory.FootballerIdForUpdate,
                    UserId = FootballersContextFactory.UserAId
                }, CancellationToken.None);
            });
        }
    }
}
