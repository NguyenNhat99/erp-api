using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Contract.DependencyInjection.Extensions;
using _365Architect.Demo.Contract.Enumerations;
using _365Architect.Demo.Contract.Validators;
using _365Architect.Demo.Domain.Constants;


namespace _365Architect.Demo.Application.Validators.Categories
{
    public class UpdateCategoryValidator : Validator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator() {
            WithValidator(MsgCode.ERR_CATEGORY_INVALID);
            RuleFor(x => x.Id).NotNull().GreaterThan(0);
            RuleFor(x => x.Name).NotNull()!.MaxLength(CategoryConst.CATEGORYNAME_MAX_LENGTH);
            RuleFor(x => x.Description)!.NotEmpty();
        
        }
    }
}
