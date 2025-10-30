using _365Architect.Demo.Domain.Abstractions.Repositories.Sql;
using _365Architect.Demo.Domain.Entities;
using _365Architect.Demo.Persistence.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Persistence.Repositories
{
    public class CategorySqlRepository : GenericSqlRepository<Category, int>, ICategorySqlRepository
    {
        public CategorySqlRepository(ApplicationDbContext context) : base(context)
        {
        }
        public void Add(Category entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            base.Add(entity);
        }
        public void Update(Category entity)
        {
            entity.UpdatedAt = DateTime.UtcNow;
            base.Update(entity);
        }
    }
}
