using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Contract.DependencyInjection.Extensions;
using _365Architect.Demo.Contract.Enumerations;
using _365Architect.Demo.Contract.Validators;
namespace _365Architect.Demo.Application.Validators.Categories
{
    public class DeleteCategoryValidator : Validator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator() {
            WithValidator(MsgCode.ERR_CATEGORY_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);    
        }
    }
}
