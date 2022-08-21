using System;
using Footballer.Persistence;

namespace Footballers.Tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly FootballersDbContext Context;

        public TestCommandBase()
        {
            Context = FootballersContextFactory.Create();
        }

        public void Dispose()
        {
            FootballersContextFactory.Destroy(Context);
        }
    }
}
