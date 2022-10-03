using System;
using MediatR;

namespace Footballers.Application.Footballers.Commands.UpdateFootballer
{
    public class UpdateFootballerCommand : IRequest
    {
        public Guid UserId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Number { get; set; }
        public string Position { get; set; }
    }
}