using System;
using MediatR;

namespace Footballers.Application.Footballers.Commands.CreateFootballer
{
    public class CreateFootballerCommand : IRequest<int>
    {
        public Guid UserId { get; set; }
        public int FootballerId { get; set;}
        public string Name { get; set; }
        public string LastName { get; set; }
        public int number { get; set; }
        public string position { get; set; }
    }
}