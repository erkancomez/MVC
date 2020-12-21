using Erkan.ToDo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Entities.Concrete
{
    public class Report:ITable
    {
        public int Id { get; set; }
        public string Describtion { get; set; }
        public string Detail { get; set; }

        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
