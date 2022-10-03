using System;
using FluentValidation;
using Footballers.Application.Footballers.Commands.CreateFootballer;

namespace Commands.CreateFootballer
{
    public class CreateFootballerCommandValidator : AbstractValidator<CreateFootballerCommand>
    {
        public CreateFootballerCommandValidator()
        {
            RuleFor(createFootballerCommand =>
                createFootballerCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(createFootballerCommand =>
                createFootballerCommand.LastName).NotEmpty().MaximumLength(250);
            RuleFor(createFootballerCommand =>
                createFootballerCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(createFootballerCommand =>
                createFootballerCommand.FootballerId).NotNull();
        }
    }
}
