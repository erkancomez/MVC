using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _userDal;

        public AppUserManager(IAppUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<AppUser> GetNonAdmin()
        {
            return _userDal.GetNonAdmin();
        }

        public List<AppUser> GetNonAdmin(out int totalPage, string searchingWord, int activePaging)
        {
            return _userDal.GetNonAdmin(out totalPage, searchingWord, activePaging);
        }
    }
}
