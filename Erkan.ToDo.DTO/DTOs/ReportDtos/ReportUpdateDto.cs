using Erkan.ToDo.Entities.Concrete;

namespace Erkan.ToDo.DTO.DTOs.ReportDtos
{
    public class ReportUpdateDto
    {
        public int Id { get; set; }
        public string Detail { get; set; }
        public string Describtion { get; set; }
        public Task Task { get; set; }
        public int TaskId { get; set; }
    }
}
