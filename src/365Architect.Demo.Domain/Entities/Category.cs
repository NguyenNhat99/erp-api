using _365Architect.Demo.Domain.Abstractions.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Domain.Entities
{
    public class Category : AggregateRoot<int>
    {
        public string Name { set; get; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public ICollection<Sample> Samples { get; set; } = new List<Sample>();
    }
}
