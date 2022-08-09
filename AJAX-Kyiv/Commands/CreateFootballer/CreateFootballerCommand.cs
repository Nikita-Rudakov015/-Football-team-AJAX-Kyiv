using System;
using MediatR;

namespace Footballers.Application.Footballers.Commands.CreateFootballer
{
    public class CreateFootballerCommand : IRequest<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int number { get; set; }
        public string position { get; set; }
    }
}