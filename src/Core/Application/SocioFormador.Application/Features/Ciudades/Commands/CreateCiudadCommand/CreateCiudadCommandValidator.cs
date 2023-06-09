using FluentValidation;

namespace SocioFormador.Application.Features.Ciudades.Commands.CreateCiudadCommand;

public class CreateCiudadCommandValidator : AbstractValidator<CreateCiudadCommand>
{
    public CreateCiudadCommandValidator()
    {
        RuleFor(c => c.Nombre)
           .NotEmpty()
           .WithMessage("{PropertyName} is required.")
           .NotNull()
           .MaximumLength(100)
           .WithMessage("{PropertyName} must not exceed 100 characters.");
    }
}
