using _365Architect.Demo.Contract.Abstractions;
using _365Architect.Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Application.Requests.Categories
{
    public class GetCategoryByIdQuery : IQuery<Category>
    {
        public int? Id { get; set; }    
    }
}
