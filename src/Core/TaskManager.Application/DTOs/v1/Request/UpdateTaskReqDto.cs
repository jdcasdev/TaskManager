namespace TaskManager.Application.DTOs.v1.Request
{
    public class UpdateTaskReqDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Status { get; set; }
        public DateTime EventDateTime { get; set; }
    }
}
