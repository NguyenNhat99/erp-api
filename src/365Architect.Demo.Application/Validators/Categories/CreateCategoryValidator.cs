using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Contract.DependencyInjection.Extensions;
using _365Architect.Demo.Contract.Enumerations;
using _365Architect.Demo.Contract.Validators;
using _365Architect.Demo.Domain.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Application.Validators.Categories
{
    public class CreateCategoryValidator : Validator<CreateCategoryCommand>
    {
        public CreateCategoryValidator() {
            WithValidator(MsgCode.ERR_CATEGORY_INVALID);
            RuleFor(x => x.Name).NotNull()!.MaxLength(CategoryConst.CATEGORYNAME_MAX_LENGTH);
            RuleFor(x => x.Description).NotNull()!.MaxLength(CategoryConst.DESCRIPTION_MAX_LENGTH);
        }
    }
}
