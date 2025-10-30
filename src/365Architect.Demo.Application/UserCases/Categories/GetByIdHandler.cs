using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Application.Validators.Categories;
using _365Architect.Demo.Contract.Shared;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql;
using _365Architect.Demo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Application.UserCases.Categories
{
    public class GetByIdHandler : IRequestHandler<GetCategoryByIdQuery, Result<Category>>
    {
        private readonly ICategorySqlRepository _repo;

        public GetByIdHandler(ICategorySqlRepository repo) {
            _repo = repo;
        
        }
        public async Task<Result<Category>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            GetByIdValidator validator = new GetByIdValidator();
            validator.ValidateAndThrow(request);

            Category category = await _repo.FindByIdAsync((int)request.Id,false, cancellationToken);
            return category;
        }
    }
}
