using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework;
using Erkan.ToDo.Entities.Concrete;
using System.Collections.Generic;

namespace Erkan.ToDo.Business.Concrete
{
    class WorkingManager:IWorkingService
    {
        private readonly EfWorkingRepository efWorkingRepository;

        public WorkingManager()
        {
            efWorkingRepository = new EfWorkingRepository();
        }
        public void Delete(Working table)
        {
            efWorkingRepository.Delete(table);
        }

        public List<Working> GetAllWorkings()
        {
            return efWorkingRepository.GetAllWorkings();
        }

        public Working GetId(int Id)
        {
            return efWorkingRepository.GetId(Id);
        }

        public void Save(Working table)
        {
            efWorkingRepository.Save(table);
        }

        public void Update(Working table)
        {
            efWorkingRepository.Update(table);
        }
    }
}
