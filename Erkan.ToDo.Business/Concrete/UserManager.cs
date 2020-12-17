using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Concrete
{
    public class UserManager : IUserService 
    {
        private readonly EfUserRepository efUserRepository;

        public UserManager()
        {
            efUserRepository = new EfUserRepository();
        }
        public void Delete(User table)
        {
            efUserRepository.Delete(table);
        }

        public List<User> GetAllWorkings()
        {
            return efUserRepository.GetAllWorkings();
        }

        public User GetId(int Id)
        {
            return efUserRepository.GetId(Id);
        }

        public void Save(User table)
        {
            efUserRepository.Save(table);
        }

        public void Update(User table)
        {
            efUserRepository.Update(table);
        }
    }
}
