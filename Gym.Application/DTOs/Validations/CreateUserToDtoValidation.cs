using FluentValidation;
using Gym.Application.DTOs.Gym;
using Gym.Application.DTOs.User;

namespace Gym.Application.DTOs.Validations
{
    public class CreateUserToDtoValidation : AbstractValidator<CreateUserDTO>
    {
        public CreateUserToDtoValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id deve ser informado!");

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome deve ser informada!");

            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("Email deve ser informado!");

            RuleFor(x => x.RoleId)
                .NotEmpty()
                .NotNull()
                .WithMessage("Role deve ser informada!");
        }
    }
}
