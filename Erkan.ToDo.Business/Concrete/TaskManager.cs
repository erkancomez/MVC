using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework;
using Erkan.ToDo.Entities.Concrete;
using System.Collections.Generic;

namespace Erkan.ToDo.Business.Concrete
{
    public class TaskManager:ITaskService
    {
        private readonly EfTaskRepository efWorkingRepository;

        public TaskManager()
        {
            efWorkingRepository = new EfTaskRepository();
        }
        public void Delete(Task table)
        {
            efWorkingRepository.Delete(table);
        }

        public List<Task> GetAll()
        {
            return efWorkingRepository.GetAll();
        }

        public Task GetId(int Id)
        {
            return efWorkingRepository.GetId(Id);
        }

        public void Save(Task table)
        {
            efWorkingRepository.Save(table);
        }

        public void Update(Task table)
        {
            efWorkingRepository.Update(table);
        }
    }
}
