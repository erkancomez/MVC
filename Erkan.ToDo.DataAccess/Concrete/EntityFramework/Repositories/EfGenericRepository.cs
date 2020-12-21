using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts;
using Erkan.ToDo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table>
        where Table : class, ITable, new()
    {
        public void Delete(Table table)
        {
            using var context = new ToDoContext();
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }

        public List<Table> GetAll()
        {
            using var context = new ToDoContext();
            return context.Set<Table>().ToList();
        }

        public Table GetId(int Id)
        {
            using var context = new ToDoContext();
            return context.Set<Table>().Find(Id);
        }

        public void Save(Table table)
        {
            using var context = new ToDoContext();
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Update(Table table)
        {
            using var context = new ToDoContext();
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }
    }
}
