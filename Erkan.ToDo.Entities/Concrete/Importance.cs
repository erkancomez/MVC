using Erkan.ToDo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Entities.Concrete
{
    public class Importance : ITable
    {
        public int Id { get; set; }
        public string Definition { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
