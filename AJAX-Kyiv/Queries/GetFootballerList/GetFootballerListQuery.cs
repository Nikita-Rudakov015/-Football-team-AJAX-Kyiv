using System;
using MediatR;

namespace Footballers.Application.Footballers.Queries.GetFootballerList
{
    public class GetFootballerListQuery : IRequest<FootballerListVm>
    {
        public Guid UserId { get; set; }
    }
}
