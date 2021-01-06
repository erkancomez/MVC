using Erkan.ToDo.DTO.DTOs.TaskDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erkan.ToDo.DTO.DTOs.AppUserDtos
{
    public class StaffTaskListDto
    {
        public AppUserListDto AppUser { get; set; }
        public TaskListDto Task { get; set; }
    }
}
