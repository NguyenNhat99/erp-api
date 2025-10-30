
using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Application.Validators.Categories;
using _365Architect.Demo.Contract.DependencyInjection.Extensions;
using _365Architect.Demo.Contract.Shared;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql.Base;
using _365Architect.Demo.Domain.Entities;
using MediatR;
using System.Data;

namespace _365Architect.Demo.Application.UserCases.Categories
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, Result<object>>
    {
        private readonly ICategorySqlRepository _repo;
        private readonly ISqlUnitOfWork _sqlUnitOfWork;

        public UpdateCategoryHandler(ICategorySqlRepository repo, ISqlUnitOfWork sqlUnitOfWork) {

            _repo = repo;
            _sqlUnitOfWork = sqlUnitOfWork;
        }

        public async Task<Result<object>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            UpdateCategoryValidator validator = new UpdateCategoryValidator();
            validator.ValidateAndThrow(request);

            Category category = await _repo.FindByIdAsync((int)request.Id, true, cancellationToken);

            request.MapTo(category);

            using IDbTransaction transaction = await _sqlUnitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                _repo.Update(category);

                await _sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                transaction.Commit();

                return Result<object>.Ok();
            }
            catch(Exception)
            {
                transaction.Rollback();
                throw;
            }
        }
    }
}
