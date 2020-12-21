using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfImportanceRepository : EfGenericRepository<Importance>, IImportanceDal
    {
    }
}
