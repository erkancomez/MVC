using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories;
using Erkan.ToDo.Entities.Concrete;
using System.Collections.Generic;

namespace Erkan.ToDo.Business.Concrete
{
    public class ImportanceManager : IImportanceService
    {
        private readonly IImportanceDal _importanceDal;
        public ImportanceManager(IImportanceDal importanceDal)
        {
            _importanceDal = importanceDal;
        }
        public void Delete(Importance table)
        {
            _importanceDal.Delete(table);
        }

        public List<Importance> GetAll()
        {
            return _importanceDal.GetAll();
        }

        public Importance GetId(int Id)
        {
            return _importanceDal.GetId(Id);
        }

        public void Save(Importance table)
        {
            _importanceDal.Save(table);
        }

        public void Update(Importance table)
        {
            _importanceDal.Update(table);
        }
    }
}
