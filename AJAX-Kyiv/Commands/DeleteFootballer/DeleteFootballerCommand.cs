using System;
using MediatR;

namespace Footballers.Application.Footballers.Commands.DeleteFootballer
{
    public class DeleteFootballerCommand : IRequest
    {
        public Guid UserId { get; set; }
        public int Id { get; set; }
    }
}