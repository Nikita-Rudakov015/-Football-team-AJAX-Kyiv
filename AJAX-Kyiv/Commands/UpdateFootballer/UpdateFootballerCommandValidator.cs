using System;
using FluentValidation;
using Footballers.Application.Footballers.Commands.UpdateFootballer;

namespace Commands.UpdateFootballer
{
    public class UpdateFootballerCommandValidator : AbstractValidator<UpdateFootballerCommand>
    {
        public UpdateFootballerCommandValidator()
        {
            RuleFor(updateFootballerCommand =>
                updateFootballerCommand.Name).NotEmpty().MaximumLength(250);
            RuleFor(updateFootballerCommand =>
                updateFootballerCommand.LastName).NotEmpty().MaximumLength(250);
            RuleFor(updateFootballerCommand =>
                updateFootballerCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
