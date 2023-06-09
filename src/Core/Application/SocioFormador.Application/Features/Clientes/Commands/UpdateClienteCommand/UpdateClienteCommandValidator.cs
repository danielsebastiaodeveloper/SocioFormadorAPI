using FluentValidation; 

namespace SocioFormador.Application.Features.Clientes.Commands.UpdateClienteCommand;

public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
{
    public UpdateClienteCommandValidator()
    {
        RuleFor(c => c.Id)
       .NotEmpty()
       .WithMessage("{PropertyName} is required.");

        RuleFor(c => c.Nombre)
        .NotEmpty()
        .WithMessage("{PropertyName} is required.")
        .NotNull()
        .MaximumLength(100)
        .WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(c => c.Apellido)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(100)
            .WithMessage("{PropertyName} must not exceed 100 characters.");

        RuleFor(c => c.Email)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(100)
            .WithMessage("{PropertyName} must not exceed 100 characters.")
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid e-mail");

        RuleFor(c => c.CiudadId)
           .NotEmpty()
           .WithMessage("{PropertyName} is required.");
    }
}
