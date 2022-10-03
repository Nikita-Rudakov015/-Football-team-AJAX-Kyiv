using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using MediatR;
using Footballers.Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Footballers.Application.Footballers.Queries.GetFootballerList
{
    public class GetFootballerListQueryHandler
        : IRequestHandler<GetFootballerListQuery, FootballerListVm>
    {
        private readonly IFootballersDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFootballerListQueryHandler(IFootballersDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FootballerListVm> Handle(GetFootballerListQuery request,
            CancellationToken cancellationToken)
        {
            var footballersQuery = await _dbContext.Footballers
                .Where(footballers => footballers.UserId == request.UserId)
                .ProjectTo<FootballerLookUpDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FootballerListVm { Footballers = footballersQuery };
        }
    }
}
