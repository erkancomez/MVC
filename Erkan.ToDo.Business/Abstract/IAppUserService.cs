using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetNonAdmin();
        List<AppUser> GetNonAdmin(string searchingWord, int activePaging);
    }
}
