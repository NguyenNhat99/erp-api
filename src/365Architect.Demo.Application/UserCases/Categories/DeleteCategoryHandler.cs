using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Application.Requests.Samples;
using _365Architect.Demo.Application.Validators.Categories;
using _365Architect.Demo.Contract.Shared;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql.Base;
using _365Architect.Demo.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Application.UserCases.Categories
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, Result<object>>
    {
        private readonly ICategorySqlRepository _repo;
        private readonly ISqlUnitOfWork _sqlUnitOfWork;

        public DeleteCategoryHandler(ICategorySqlRepository repo, ISqlUnitOfWork sqlUnitOfWork) {
            _repo = repo;
            _sqlUnitOfWork = sqlUnitOfWork;
        }
        public async Task<Result<object>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            DeleteCategoryValidator validator = new DeleteCategoryValidator();
            validator.ValidateAndThrow(request);

            Category deleteCategory = await _repo.FindByIdAsync((int) request.Id,true,cancellationToken);

            using IDbTransaction transaction = await _sqlUnitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                _repo.Remove(deleteCategory);

                await _sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                transaction.Commit();

                return Result<object>.Ok();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }

        }
    }
}
