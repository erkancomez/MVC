using Erkan.ToDo.Entities.Abstract;
using System;

namespace Erkan.ToDo.Entities.Concrete
{
    public class Working:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Statement { get; set; }
        public bool Explanation { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
