using Erkan.ToDo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Abstract
{
    public interface IGenericService<Table> where Table:class,ITable,new()
    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table GetId(int Id);
        List<Table> GetAllWorkings();
    }
}
