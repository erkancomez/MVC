using Erkan.ToDo.Entities.Concrete;


namespace Erkan.ToDo.Web.Areas.Admin.Models
{
    public class StaffTaskListViewModel
    {
        public AppUserListViewModel AppUser { get; set; }
        public TaskListViewModel Task { get; set; }
    }
}
