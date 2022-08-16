using System;
using FluentValidation;
using Footballers.Application.Footballers.Commands.DeleteFootballer;

namespace Commands.DeleteFootballer
{
    public class DeleteFootballerCommandValidator : AbstractValidator<DeleteFootballerCommand>
    {
        public DeleteFootballerCommandValidator()
        {
            RuleFor(deleteFootballerCommand =>
                deleteFootballerCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(deleteFootballerCommand =>
                deleteFootballerCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
