using _365Architect.Demo.Contract.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Application.Requests.Categories
{
    public class UpdateCategoryCommand : ICommand
    {
        public int? Id { set; get; }
        public string? Name { set; get; }
        public string? Description { set; get; }
    }
}
