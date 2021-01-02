﻿using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Erkan.ToDo.DataAccess.Abstract
{
    public interface ITaskDal : IGenericDal<Task>
    {
        List<Task> GetByImportanceIncomplete();
        List<Task> GetAllTable();
        List<Task> GetAllTable(Expression<Func<Task,bool>> filter);
        Task GetImportanceById(int id);
        List<Task> GetByAppUserId(int appUserId);
        Task GetByTaskId(int id);
    }
}
