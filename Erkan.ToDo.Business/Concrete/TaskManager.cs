﻿using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.DataAccess.Abstract;
using Erkan.ToDo.DataAccess.Concrete.EntityFramework;
using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Erkan.ToDo.Business.Concrete
{
    public class TaskManager:ITaskService
    {
        private readonly ITaskDal _taskDal;

        public TaskManager(ITaskDal taskService)
        {
            _taskDal = taskService;
            
        }
        public void Delete(Task table)
        {
            _taskDal.Delete(table);
        }

        public List<Task> GetAll()
        {
            return _taskDal.GetAll();
        }

        public List<Task> GetAllTable()
        {
            return _taskDal.GetAllTable();
        }

        public List<Task> GetAllTable(Expression<Func<Task, bool>> filter)
        {
            return _taskDal.GetAllTable(filter);
        }

        public List<Task> GetByAppUserId(int appUserId)
        {
            return _taskDal.GetByAppUserId(appUserId);
        }

        public List<Task> GetByImportanceIncomplete()
        {
            return _taskDal.GetByImportanceIncomplete();
        }

        public Task GetByTaskId(int id)
        {
            return _taskDal.GetByTaskId(id);
        }

        public Task GetId(int Id)
        {
            return _taskDal.GetId(Id);
        }

        public Task GetImportanceById(int id)
        {
            return _taskDal.GetImportanceById(id);
        }

        public void Save(Task table)
        {
            _taskDal.Save(table);
        }

        public void Update(Task table)
        {
            _taskDal.Update(table);
        }
    }
}
