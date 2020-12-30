using Erkan.ToDo.Entities.Concrete;
using System;
using System.Collections.Generic;


namespace Erkan.ToDo.Web.Areas.Admin.Models
{
    public class TaskListAllViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Explanation { get; set; }
        public DateTime CreatedDate { get; set; }
        public Importance Importance { get; set; }
        public AppUser AppUser { get; set; }
        public List<Report> Reports { get; set; }
    }
}
