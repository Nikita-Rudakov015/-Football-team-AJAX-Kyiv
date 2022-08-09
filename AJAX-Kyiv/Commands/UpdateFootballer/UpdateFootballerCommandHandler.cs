using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Footballers.Application.Interfaces;
using Footballers.Application.Common.Exceptions;
using AJAX_Kyiv.Domain;

namespace Footballers.Application.Footballers.Commands.UpdateFootballer
{
    public class UpdateFootballerCommandHandler
        : IRequestHandler<UpdateFootballerCommand>
    {
        private readonly IFootballersDbContext _dbContext;

        public UpdateFootballerCommandHandler(IFootballersDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateFootballerCommand request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Footballers.FirstOrDefaultAsync(note =>
                    note.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Footballer), request.Id);
            }

            entity.Name = request.Name;
            entity.LastName = request.LastName;
            entity.number = request.number;
            entity.position = request.position;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}