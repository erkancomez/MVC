using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Abstract
{
    public interface ITaskService:IGenericService<Task>
    {
        List<Task> GetByImportanceIncomplete();
        List<Task> GetAllTable();
        Task GetImportanceById(int id);
        List<Task> GetByAppUserId(int appUserId);
    }
}
