using FluentValidation;
using Gym.Application.DTOs.Role;

namespace Gym.Application.DTOs.Validations
{
    public class RoleDtoValidation : AbstractValidator<RoleDTO>
    {
        public RoleDtoValidation()
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
                .NotEmpty()
                .NotNull()
                .WithMessage("Tipo deve ser informado!");
        }
    }
}
