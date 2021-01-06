using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly IReportDal _reportDal;
        public ReportManager(IReportDal reportDal)
        {
            _reportDal = reportDal;
        }
        public void Delete(Report table)
        {
            _reportDal.Delete(table);
        }

        public List<Report> GetAll()
        {
            return _reportDal.GetAll();
        }

        public Report GetByTaskId(int id)
        {
            return _reportDal.GetByTaskId(id);
        }

        public Report GetId(int Id)
        {
            return _reportDal.GetId(Id);
        }

        public int GetReportCount()
        {
            return _reportDal.GetReportCount();
        }

        public int GetReportCountByAppUserId(int id)
        {
            return _reportDal.GetReportCountByAppUserId(id);
        }

        public void Save(Report table)
        {
            _reportDal.Save(table);
        }

        public void Update(Report table)
        {
            _reportDal.Update(table);
        }
    }
}
