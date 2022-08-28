using System;
using AutoMapper;
using Footballers.Application.Footballers.Queries.GetFootballerDetails;
using Footballer.Persistence;
using Footballers.Tests.Common;
using Shouldly;
using Xunit;
using System.Threading;
using System.Threading.Tasks;

namespace Footballers.Tests.Footballers.Queries
{
    [Collection("QueryCollection")]
    public class GetFootballerDetailsQueryHandlerTests
    {
        private readonly FootballersDbContext Context;
        private readonly IMapper Mapper;

        public GetFootballerDetailsQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetFootballerDetailsQueryHandlerSuccess()
        {
            //Arrange
            var handler = new GetFootballersDeatailsQueryHandler(Context, Mapper);
            //Act
            var result = await handler.Handle(
                new GetFootballersDeatailsQuery
                {
                    UserId = FootballersContextFactory.UserBId,
                    Id = Guid.Parse("81E68DE8-5D2A-4EA0-AE57-DF660112B88F")
                }, CancellationToken.None);
            //Assert
            result.ShouldBeOfType<FootballerDetailsVm>();
            result.Name.ShouldBe("Player2");
            result.LastName.ShouldBe("PlayerLastName2");
            result.number.ShouldBe(25);
            result.position.ShouldBe("RB");
        }
    }
}