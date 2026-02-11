using FluentValidation;
using TaskManager.Application.Commands.v1;

namespace TaskManager.Application.Validators
{
    public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("El Id debe de ser mayor que 0.");
        }
    }
}
