using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.Constraints
{
    public class Programming : IRouteConstraint
    {
        public List<string> programmingLanguage = new List<string> { "csharp", "java", "php" };
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return programmingLanguage.Contains(values[routeKey].ToString().ToLower());
        }
    }
}
