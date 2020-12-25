using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Areas.Admin.Models
{
    public class TaskListViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Explanation { get; set; }
        public bool Statement { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ImportanceId { get; set; }
        public Importance Importance { get; set; }
    }
}
