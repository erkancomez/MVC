using Erkan.ToDo.Entities.Concrete;
using System.Collections.Generic;

namespace Erkan.ToDo.DataAccess.Abstract
{
    public interface ITaskDal:IGenericDal<Task>
    {
        List<Task> GetByImportanceIncomplete();
    }
}
