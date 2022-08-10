using System;

namespace AJAXKyiv.Domain
{
    public class Footballer
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int number { get; set; }
        public string position { get; set; }
    }
}
