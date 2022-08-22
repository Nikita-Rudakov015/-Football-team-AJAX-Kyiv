using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Footballers.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Footballers.Application.Common.Exceptions;

namespace Footballers.Application.Footballers.Queries.GetFootballerDetails
{
    public class GetFootballersDeatailsQueryHandler
        : IRequestHandler<GetFootballersDeatailsQuery, FootballerDetailsVm>
    {
        private readonly IFootballersDbContext _dbContext;

        private readonly IMapper _mapper;

        public GetFootballersDeatailsQueryHandler(IFootballersDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FootballerDetailsVm> Handle(GetFootballersDeatailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Footballers
                .FirstOrDefaultAsync(footballer =>
                footballer.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(AJAXKyiv.Domain.Footballer), request.Id);
            }

            return _mapper.Map<FootballerDetailsVm>(entity);
        }
    }
}
