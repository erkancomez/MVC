using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Business.Abstract
{
    public interface IAppUserService
    {
        List<AppUser> GetNonAdmin();
        List<AppUser> GetNonAdmin(out int totalPage, string searchingWord, int activePaging = 1);
        List<DualHelper> GetMostCompletedStaff();
        List<DualHelper> GetMostWorkingStaff();
    }
}
