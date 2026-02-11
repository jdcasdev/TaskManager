using MediatR;

namespace TaskManager.Application.Commands.v1
{
    public class DeleteTaskCommand(int id) : IRequest
    {
        public int Id { get; set; } = id;
    }
}
