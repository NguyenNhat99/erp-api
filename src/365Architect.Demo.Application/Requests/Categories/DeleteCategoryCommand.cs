using _365Architect.Demo.Contract.Abstractions;

namespace _365Architect.Demo.Application.Requests.Categories
{
    public class DeleteCategoryCommand : ICommand
    {
        public int? Id { get; set; }
    }
}
