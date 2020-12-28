using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DataAccess.Abstract
{
    public interface IAppUserDal
    {
        List<AppUser> GetNonAdmin();
        List<AppUser> GetNonAdmin(out int totalPage, string searchingWord, int activePaging = 1);
    }
}
