using Erkan.ToDo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.ViewComponents
{
    public class Products : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("New",new List<CustomerViewModel>()
            {
                new CustomerViewModel(){Name="Erkan0"},
                new CustomerViewModel(){Name="Erkan1"},
                new CustomerViewModel(){Name="Erkan2"},
                new CustomerViewModel(){Name="Erkan3"},
                new CustomerViewModel(){Name="Erkan4"}
            });
        }
    }
}
