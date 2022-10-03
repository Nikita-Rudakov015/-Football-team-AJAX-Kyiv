using Footballers.Application.Common.Exceptions;
using Footballers.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AJAXKyiv.Domain;

namespace Footballers.Application.Footballers.Commands.DeleteFootballer
{
    public class DeleteFootballerCommandHandler
        : IRequestHandler<DeleteFootballerCommand>
    {
        private readonly IFootballersDbContext _dbContext;

        public DeleteFootballerCommandHandler(IFootballersDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteFootballerCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Footballers
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Footballer), request.UserId);
            }

            _dbContext.Footballers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
