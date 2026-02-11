using FluentValidation;
using TaskManager.Application.Queries.v1;

namespace TaskManager.Application.Validators
{
    public class GetTaskByIdQueryValidator : AbstractValidator<GetTaskByIdQuery>
    {
        public GetTaskByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("El Id debe de ser mayor que 0.");
        }
    }
}
