using Erkan.ToDo.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Erkan.ToDo.Entities.Concrete
{
    public class Task:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public bool Statement { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ImportanceId { get; set; }
        public Importance Importance { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }

    }
}
