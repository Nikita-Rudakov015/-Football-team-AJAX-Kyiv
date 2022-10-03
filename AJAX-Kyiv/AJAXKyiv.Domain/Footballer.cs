using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AJAXKyiv.Domain
{
    public class Footballer
    {
        public Guid UserId { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int number { get; set; }
        public string position { get; set; }
    }
}
