using FluentValidation;
using TaskManager.Application.Commands.v1;

namespace TaskManager.Application.Validators
{
    public class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("El Id no puede estar vacío.")
                .Length(24)
                .WithMessage("El Id debe contener exactamente 24 dígitos.");
        }
    }
}
