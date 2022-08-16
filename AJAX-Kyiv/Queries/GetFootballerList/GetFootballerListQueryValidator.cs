using System;
using FluentValidation;
using Footballers.Application.Footballers.Queries.GetFootballerList;

namespace Queries.GetFootballerList
{
    public class GetFootballerListQueryValidator : AbstractValidator<GetFootballerListQuery>
    {
        public GetFootballerListQueryValidator()
        {
            RuleFor(footballer => footballer.UserId).NotEqual(Guid.Empty);
        }
    }
}
