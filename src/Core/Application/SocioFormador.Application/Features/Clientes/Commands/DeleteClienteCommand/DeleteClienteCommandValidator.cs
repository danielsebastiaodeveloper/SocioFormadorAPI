using FluentValidation;

namespace SocioFormador.Application.Features.Clientes.Commands.DeleteClienteCommand;

public class DeleteClienteCommandValidator : AbstractValidator<DeleteClienteCommand>
{
    public DeleteClienteCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("{PropertyName} is required.");
    }
}