using FluentValidation;
using Gym.Application.DTOs.Role;

namespace Gym.Application.DTOs.Validations
{
    public class CreateRoleDtoValidation : AbstractValidator<CreateRoleDTO>
    {
        public CreateRoleDtoValidation()
        {
            RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull()
            .WithMessage("Id deve ser informado!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informado!");

            RuleFor(x => x.RoleType)
                .NotNull()
                .WithMessage("Tipo deve ser informado!");
        }
    }
}
