using MediatR;

namespace TaskManager.Application.Commands.v1
{
    public class DeleteTaskCommand(string id) : IRequest
    {
        public string Id { get; set; } = id;
    }
}
