using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erkan.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("erkan")]
    public class Paragraf:TagHelper
    {
        public string EnterTheData { get; set; } = "Erkan Çömez";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //var stringBuilder = new StringBuilder();
            //stringBuilder.AppendFormat("<p> <b> {0} </b> </p>", "Erkan Çömez");
            //output.Content.SetHtmlContent(stringBuilder.ToString());
            //base.Process(context, output);

            string data = string.Empty;

            data = "<p> <b>" +EnterTheData + "</b> </p>";
            output.Content.SetHtmlContent(data);
        }
    }
}
