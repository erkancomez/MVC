using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework
{
    public class EfTaskRepository : EfGenericRepository<Task>, ITaskDal
    {
    }
}
