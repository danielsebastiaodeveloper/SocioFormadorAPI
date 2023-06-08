

using FluentValidation;

namespace SocioFormador.Application.Features.Clientes.Commands.CreateClienteCommand;

public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
{
    public CreateClienteCommandValidator()
    {
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
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(100)
            .WithMessage("{PropertyName} must not exceed 100 characters.")
            .EmailAddress()
            .WithMessage("{PropertyName} must be a valid e-mail");
    }
}
