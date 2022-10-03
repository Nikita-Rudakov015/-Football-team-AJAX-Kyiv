using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Footballers.Application.Interfaces;

namespace Footballers.Application.Footballers.Commands.CreateFootballer
{
    public class CreateFootballerCommandHandler
        : IRequestHandler<CreateFootballerCommand, int>
    {
        private readonly IFootballersDbContext _dbContext;

        public CreateFootballerCommandHandler(IFootballersDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<int> Handle(CreateFootballerCommand request,
            CancellationToken cancellationToken)
        {
            var footballer = new AJAXKyiv.Domain.Footballer
            {
                Id = request.FootballerId,
                Name = request.Name,
                LastName = request.LastName,
                number = request.number,
                position = request.position,
            };

            await _dbContext.Footballers.AddAsync(footballer, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return footballer.Id;
        }
    }
}