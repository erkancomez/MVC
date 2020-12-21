using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories;
using Erkan.ToDo.Entities.Concrete;
using System.Collections.Generic;

namespace Erkan.ToDo.Business.Concrete
{
    public class ImportanceManager : IImportanceService
    {
        private readonly EfImportanceRepository efImportanceRepository;
        public ImportanceManager()
        {
            efImportanceRepository = new EfImportanceRepository();
        }
        public void Delete(Importance table)
        {
            efImportanceRepository.Delete(table);
        }

        public List<Importance> GetAll()
        {
            return efImportanceRepository.GetAll();
        }

        public Importance GetId(int Id)
        {
            return efImportanceRepository.GetId(Id);
        }

        public void Save(Importance table)
        {
            efImportanceRepository.Save(table);
        }

        public void Update(Importance table)
        {
            efImportanceRepository.Update(table);
        }
    }
}
