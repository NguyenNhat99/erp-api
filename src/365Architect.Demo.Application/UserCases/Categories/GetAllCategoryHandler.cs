using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Contract.Shared;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql.Base;
using _365Architect.Demo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Application.UserCases.Categories
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery, Result<List<Category>>>
    {
        private readonly ICategorySqlRepository _repo;

        public GetAllCategoryHandler(ICategorySqlRepository repo) 
        {
            _repo = repo;
        }
        public Task<Result<List<Category>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult<Result<List<Category>>>(_repo.FindAll().ToList());
        }
    }
}
