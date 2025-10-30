using _365Architect.Demo.Contract.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Application.Requests.Categories
{
    public class CreateCategoryCommand : ICommand
    {
        public string? Name { set; get; }
        public string? Description { set; get; } = string.Empty;
    }
}
