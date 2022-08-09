using System;
using MediatR;

namespace Footballers.Application.Footballers.Commands.UpdateFootballer
{
    public class UpdateFootballerCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int number { get; set; }
        public string position { get; set; }
    }
}