using System;
using Footballer.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Footballers.Tests.Common
{
    public class FootballersContextFactory
    {
        public static Guid UserAId = Guid.NewGuid();
        public static Guid UserBId = Guid.NewGuid();

        public static int FootballerIdForDelete;
        public static int FootballerIdForUpdate;

        public static FootballersDbContext Create()
        {
            var options = new DbContextOptionsBuilder<FootballersDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new FootballersDbContext(options);
            context.Database.EnsureCreated();
            context.Footballers.AddRange(
                    new AJAXKyiv.Domain.Footballer
                    {
                        Name = "Player1",
                        LastName = "PlayerLastName1",
                        UserId = Guid.Parse("0F9CFBD5-5AD8-4E8A-AF15-1E4F407C5546"),
                        number = 26,
                        position = "LB",
                    },
                    new AJAXKyiv.Domain.Footballer
                    {
                        Name = "Player2",
                        LastName = "PlayerLastName2",
                        UserId = Guid.Parse("81E68DE8-5D2A-4EA0-AE57-DF660112B88F"),
                        number = 25,
                        position = "RB",
                    },
                    new AJAXKyiv.Domain.Footballer
                    {
                        Name = "Player3",
                        LastName = "PlayerLastName3",
                        Id = FootballerIdForDelete,
                        number = 27,
                        position = "CM",
                        UserId = UserAId,
                    },
                    new AJAXKyiv.Domain.Footballer
                    {
                        Name = "Player4",
                        LastName = "PlayerLastName4",
                        Id = FootballerIdForUpdate,
                        number = 28,
                        position = "CDM",
                        UserId = UserBId,
                    }
                );
            context.SaveChanges();
            return context;
        }

        public static void Destroy(FootballersDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
