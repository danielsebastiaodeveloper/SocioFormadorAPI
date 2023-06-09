using FluentValidation;

namespace SocioFormador.Application.Features.Ciudades.Commands.UpdateCiudadCommand;

public class UpdateCiudadCommandValidator: AbstractValidator<UpdateCiudadCommand>
{
    public UpdateCiudadCommandValidator()
    {
        RuleFor(c => c.Id)
          .NotNull()
          .WithMessage("{PropertyName} is required.");

        RuleFor(c => c.Nombre)
          .NotEmpty()
          .WithMessage("{PropertyName} is required.")
          .NotNull()
          .MaximumLength(100)
          .WithMessage("{PropertyName} must not exceed 100 characters.");
    }
}
