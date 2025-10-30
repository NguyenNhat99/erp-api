using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Contract.DependencyInjection.Extensions;
using _365Architect.Demo.Contract.Enumerations;
using _365Architect.Demo.Contract.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Application.Validators.Categories
{
    public class GetByIdValidator : Validator<GetCategoryByIdQuery>
    {
        public GetByIdValidator() { 
            WithValidator(MsgCode.ERR_CATEGORY_INVALID);
            RuleFor(x => x.Id).NotNull()!.GreaterThan(0);
        }
    }
}
