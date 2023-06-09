using FluentValidation;

namespace SocioFormador.Application.Features.Ciudades.Commands.DeleteCiudadCommand;

public class DeleteCiudadCommandValidator : AbstractValidator<DeleteCiudadCommand>
{
    public DeleteCiudadCommandValidator()
    {
        RuleFor(c => c.Id)
           .NotEmpty()
           .WithMessage("{PropertyName} is required.");
    }
}
