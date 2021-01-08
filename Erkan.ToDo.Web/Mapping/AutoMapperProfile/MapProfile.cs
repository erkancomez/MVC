using AutoMapper;
using Erkan.ToDo.DTO.DTOs.AppUserDtos;
using Erkan.ToDo.DTO.DTOs.ImportanceDtos;
using Erkan.ToDo.DTO.DTOs.NotificationDtos;
using Erkan.ToDo.DTO.DTOs.ReportDtos;
using Erkan.ToDo.DTO.DTOs.TaskDtos;
using Erkan.ToDo.Entities.Concrete;


namespace Erkan.ToDo.Web.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Importance-ImportanceDto
            CreateMap<ImportanceAddDto, Importance>();
            CreateMap<Importance, ImportanceAddDto>();
            CreateMap<ImportanceListDto, Importance>();
            CreateMap<Importance, ImportanceListDto>();
            CreateMap<ImportanceUpdateDto, Importance>();
            CreateMap<Importance, ImportanceUpdateDto>();
            #endregion
            
            #region AppUser-AppUserDto
            CreateMap<AppUserAddDto, AppUser>();
            CreateMap<AppUser, AppUserAddDto>();
            CreateMap<AppUserListDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserSignInDto, AppUser>();
            CreateMap<AppUser, AppUserSignInDto>();
            #endregion

            #region Notification-NotificationDto
            CreateMap<NotificationListDto, Notification>();
            CreateMap<Notification, NotificationListDto>();
            #endregion

            #region Task-TaskDto
            CreateMap<TaskAddDto, Task>();
            CreateMap<Task, TaskAddDto>();
            CreateMap<TaskListDto, Task>();
            CreateMap<Task, TaskListDto>();
            CreateMap<TaskUpdateDto, Task>();
            CreateMap<Task, TaskUpdateDto>();
            CreateMap<TaskListAllDto, Task>();
            CreateMap<Task, TaskListAllDto>();
            #endregion

            #region Report-ReportDto
            CreateMap<ReportAddDto, Report>();
            CreateMap<Report, ReportAddDto>();
            CreateMap<ReportUpdateDto, Report>();
            CreateMap<Report, ReportUpdateDto>(); 
            CreateMap<ReportFileDto, Report>();
            CreateMap<Report, ReportFileDto>();
            #endregion
        }
    }
}
