using FluentValidation;
using TaskManager.Application.Commands.v1;
using TaskManager.Application.DTOs.v1.Request;
using TaskManager.Domain;

namespace TaskManager.Application.Validators
{
    public class CreateTaskCommandValidator : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Payload)
                .NotNull()
                .WithMessage("La carga útil no está siendo enviada correctamente.")
                .SetValidator(new CreateTaskReqDtoValidator());
        }
    }

    public class CreateTaskReqDtoValidator : AbstractValidator<CreateTaskReqDto>
    {
        public CreateTaskReqDtoValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("El título es requerido.")
                .MaximumLength(100)
                .WithMessage("El título no puede tener más de 100 caracteres.");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("La descripción es requerida.")
                .MaximumLength(500)
                .WithMessage("La descripción no puede tener más de 500 caracteres.");
            RuleFor(x => x.Status)
                .NotEmpty()
                .WithMessage("El estatus es requerido.")
                .Must(status => TaskStatusNormalized.TryNormalize(status, out _))
                .WithMessage("El estatus enviado no es válido. Valores permitidos: Pendiente, En progreso, Completada.");

        }
    }
}
