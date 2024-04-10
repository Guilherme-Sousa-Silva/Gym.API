using FluentValidation;
using Gym.Application.DTOs.Gym;

namespace Gym.Application.DTOs.Validations
{
    public class CreateGymDtoValidation : AbstractValidator<CreateGymDTO>
    {
        public CreateGymDtoValidation()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Id deve ser informado!");

            RuleFor(x => x.Cnpj)
                .NotEmpty()
                .NotNull()
                .WithMessage("CNPJ deve ser informado!");

            RuleFor(x => x.RazaoSocial)
                .NotEmpty()
                .NotNull()
                .WithMessage("Razão social deve ser informada!");

            RuleFor(x => x.NomeFantasia)
                .NotEmpty()
                .NotNull()
                .WithMessage("Nome fantasia deve ser informado!");
        }
    }
}
