using Erkan.ToDo.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Entities.Concrete
{
    public class Notification:ITable
    {
        public int Id { get; set; }
        public string Explanation { get; set; }
        public bool Statement { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }

    }
}
