using System;
using FluentValidation;
using Footballers.Application.Footballers.Queries.GetFootballerDetails;

namespace Queries.GetFootballerDetails
{
    public class GetFootballersDetailsQueryValidator : AbstractValidator<GetFootballersDeatailsQuery>
    {
        public GetFootballersDetailsQueryValidator()
        {
            RuleFor(footballer => footballer.UserId).NotEqual(Guid.Empty);
            RuleFor(footballer => footballer.Id).NotEqual(Guid.Empty);
        }
    }
}
