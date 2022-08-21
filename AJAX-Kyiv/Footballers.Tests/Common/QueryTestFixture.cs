using AutoMapper;
using System;
using Footballers.Application.Interfaces;
using Footballers.Application.Common.Mapping;
using Footballer.Persistence;
using Xunit;

namespace Footballers.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public FootballersDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = FootballersContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IFootballersDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            FootballersContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollerction")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
