using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Concrete
{
    public class ReportManager : IReportService
    {
        private readonly EfReportRepository reportRepository;
        public ReportManager()
        {
            reportRepository = new EfReportRepository();
        }
        public void Delete(Report table)
        {
            reportRepository.Delete(table);
        }

        public List<Report> GetAll()
        {
            return reportRepository.GetAll();
        }

        public Report GetId(int Id)
        {
            return reportRepository.GetId(Id);
        }

        public void Save(Report table)
        {
            reportRepository.Save(table);
        }

        public void Update(Report table)
        {
            reportRepository.Update(table);
        }
    }
}
