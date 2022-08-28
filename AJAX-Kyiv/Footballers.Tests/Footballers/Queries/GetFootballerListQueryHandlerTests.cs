using AutoMapper;
using Footballer.Persistence;
using Footballers.Tests.Common;
using System.Threading;
using System.Threading.Tasks;
using Footballers.Application.Footballers.Queries.GetFootballerList;
using Xunit;
using Shouldly;

namespace Footballers.Tests.Footballers.Queries
{
    [Collection("QueryCollection")]
    public class GetFootballerListQueryHandlerTests
    {
        private readonly FootballersDbContext Context;
        private readonly IMapper Mapper;

        public GetFootballerListQueryHandlerTests(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }

        [Fact]
        public async Task GetFootballerListQueryHandlerSuccess()
        {
            //Arrange
            var handler = new GetFootballerListQueryHandler(Context, Mapper);

            //Act
            var result = await handler.Handle(
                new GetFootballerListQuery
                {
                    UserId = FootballersContextFactory.UserBId
                }, CancellationToken.None);
            //Assert
            result.ShouldBeOfType<FootballerListVm>();
            result.Footballers.Count.ShouldBe(2);
        }
    }
}

