using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework.Contexts;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erkan.ToDo.DataAccess.Concrete.EntityFramework.Repositories
{
    public class EfAppUserRepository : IAppUserDal
    {
        public List<AppUser> GetNonAdmin()
        {
            using var context = new ToDoContext();
            return context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole

            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                //user = resultTable.user,
                resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name == "Member").Select(I => new AppUser
            {
                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName

            }).ToList();
        }

        public List<AppUser> GetNonAdmin(out int totalPage, string searchingWord, int activePaging = 1)
        {


            using var context = new ToDoContext();

            var result = context.Users.Join(context.UserRoles, user => user.Id, userRole => userRole.UserId, (resultUser, resultUserRole) => new
            {
                user = resultUser,
                userRole = resultUserRole
            }).Join(context.Roles, twoTableResult => twoTableResult.userRole.RoleId, role => role.Id, (resultTable, resultRole) => new
            {
                resultTable.user,
                userRoles = resultTable.userRole,
                roles = resultRole
            }).Where(I => I.roles.Name == "Member").Select(I => new AppUser()
            {
                Id = I.user.Id,
                Name = I.user.Name,
                SurName = I.user.SurName,
                Picture = I.user.Picture,
                Email = I.user.Email,
                UserName = I.user.UserName

            });

            totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            if (!string.IsNullOrWhiteSpace(searchingWord))
            {
                result = result.Where(I => I.Name.ToLower().Contains(searchingWord.ToLower()) || I.SurName.ToLower().Contains(searchingWord.ToLower()));
                totalPage = (int)Math.Ceiling((double)result.Count() / 3);

            }



            result = result.Skip((activePaging - 1) * 3).Take(3);

            return result.ToList();

        }

        public List<DualHelper> GetMostCompletedStaff()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(I => I.AppUser).Where(I => I.Statement).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                TaskCount = I.Count()
            }).ToList();
        }
        public List<DualHelper> GetMostWorkingStaff()
        {
            using var context = new ToDoContext();
            return context.Tasks.Include(I => I.AppUser).Where(I => !I.Statement && I.AppUserId!=null).GroupBy(I => I.AppUser.UserName).OrderByDescending(I => I.Count()).Take(5).Select(I => new DualHelper
            {
                Name = I.Key,
                TaskCount = I.Count()
            }).ToList();
        }
    }
}
