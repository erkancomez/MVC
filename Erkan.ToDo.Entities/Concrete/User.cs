using Erkan.ToDo.Entities.Abstract;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Erkan.ToDo.Entities.Concrete
{
    public class User:ITable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public List<Working> Works { get; set; }


    }
}
