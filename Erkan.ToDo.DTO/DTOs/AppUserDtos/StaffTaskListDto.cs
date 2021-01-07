using Erkan.ToDo.DTO.DTOs.TaskDtos;

namespace Erkan.ToDo.DTO.DTOs.AppUserDtos
{
    public class StaffTaskListDto
    {
        public AppUserListDto AppUser { get; set; }
        public TaskListDto Task { get; set; }
    }
}
