using Erkan.ToDo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.CustomFilters
{
    public class NamecantErkan:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var dictionaryGetting = context.ActionArguments.Where(I => I.Key == "model").FirstOrDefault();
            var model = (UserSignUpViewModel)dictionaryGetting.Value;
            if (model.Name.ToLower()=="erkan")
            {
                context.Result = new RedirectResult("\\Home\\Error");
            }
        }
    }
}
