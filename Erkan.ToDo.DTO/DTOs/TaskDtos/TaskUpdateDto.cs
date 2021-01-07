using Erkan.ToDo.Entities.Concrete;

namespace Erkan.ToDo.DTO.DTOs.TaskDtos
{
    public class TaskUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Explanation { get; set; }
        public int ImportanceId { get; set; }
    }
}
