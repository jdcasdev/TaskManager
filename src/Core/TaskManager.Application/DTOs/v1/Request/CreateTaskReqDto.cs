namespace TaskManager.Application.DTOs.v1.Request
{
    public class CreateTaskReqDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
    }
}
