using Footballers.Tests.Common;
using Footballers.Application.Footballers.Commands.CreateFootballer;
using Xunit;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Footballers.Tests.Footballers.Commands
{
    public class CreateFootballerCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public async Task CreateFootballerCommandHandlerSuccess()
        {
            //Arrange
            var handler = new CreateFootballerCommandHandler(Context);
            var footballerName = "footballer name";
            var footballerLastName = "footballer last name";
            var footballerPosition = "footballer position";
            var footballerNumber = 23;

            //Act
            var footballerId = await handler.Handle(
                new CreateFootballerCommand
                {
                    Name = footballerName,
                    LastName = footballerLastName,
                    position = footballerPosition,
                    number = footballerNumber,
                    UserId = FootballersContextFactory.UserAId
                },
                CancellationToken.None);

            //Assert
            Assert.NotNull(
                await Context.Footballers.SingleOrDefaultAsync(footballer =>
                    footballer.Id == footballerId && 
                    footballer.Name == footballerName &&
                    footballer.LastName == footballerLastName && 
                    footballer.position == footballerPosition &&
                    footballer.number == footballerNumber));
        }
    }
}
