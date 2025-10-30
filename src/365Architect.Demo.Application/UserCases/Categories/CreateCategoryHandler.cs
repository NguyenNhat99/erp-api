
using _365Architect.Demo.Application.Requests.Categories;
using _365Architect.Demo.Application.Validators.Categories;
using _365Architect.Demo.Contract.DependencyInjection.Extensions;
using _365Architect.Demo.Contract.Shared;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql;
using _365Architect.Demo.Domain.Abstractions.Repositories.Sql.Base;
using _365Architect.Demo.Domain.Entities;
using MediatR;
using System.Data;
using System.Transactions;


namespace _365Architect.Demo.Application.UserCases.Categories
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, Result<object>>
    {
        private readonly ICategorySqlRepository _repo;
        private readonly ISqlUnitOfWork _sqlUnitOfWork;

        public CreateCategoryHandler(ICategorySqlRepository repo, ISqlUnitOfWork sqlUnitOfWork) {
            _repo = repo;
            _sqlUnitOfWork = sqlUnitOfWork;
        
        }
        public async Task<Result<object>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            CreateCategoryValidator validator = new CreateCategoryValidator();
            validator.ValidateAndThrow(request);

            Category? category = request.MapTo<Category>();
            
            using IDbTransaction dbTransaction = await _sqlUnitOfWork.BeginTransactionAsync(cancellationToken);

            try
            {
                _repo.Add(category);

                await _sqlUnitOfWork.SaveChangesAsync(cancellationToken);

                dbTransaction.Commit();

                return Result<object>.Ok();

            }
            catch (Exception)
            {
                dbTransaction.Rollback();
                throw;
            }
        }
    }
}
