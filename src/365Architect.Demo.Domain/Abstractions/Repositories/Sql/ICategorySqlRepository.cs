using _365Architect.Demo.Domain.Abstractions.Repositories.Sql.Base;
using _365Architect.Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Architect.Demo.Domain.Abstractions.Repositories.Sql
{
    public interface ICategorySqlRepository : IGenericSqlRepository<Category,int>
    {
    }
}
