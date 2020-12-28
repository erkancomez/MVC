using Erkan.ToDo.Business.Abstract;
using Erkan.ToDo.Entities.Concrete;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;

namespace Erkan.ToDo.Web.TagHelpers
{
    [HtmlTargetElement("GetTaskAppUserId")]
    public class TaskAppUserIdTagHelper : TagHelper
    {
        private readonly ITaskService _taskService;

        public TaskAppUserIdTagHelper(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public int AppUserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            List<Task> tasks = _taskService.GetByAppUserId(AppUserId);
            int completed = tasks.Where(I => I.Statement).Count();
            int inCompleted = tasks.Where(I => !I.Statement).Count();
            string htmlString = $"Tamamladığı görev sayısı: {completed} <br>  Üstünde çalıştığı görev sayısı: {inCompleted}";
            output.Content.SetHtmlContent(htmlString);

        }
    }
}
