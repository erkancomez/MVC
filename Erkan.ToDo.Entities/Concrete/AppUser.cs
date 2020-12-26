using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.Entities.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Picture { get; set; }

        public List<Task> Tasks { get; set; }
    }
}
