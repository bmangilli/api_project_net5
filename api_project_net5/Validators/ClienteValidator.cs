using FluentValidation;
using Clientes.Models;

namespace Clientes.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(cliente => cliente.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório")
                .MaximumLength(100)
                .WithMessage("Nome deve ter no máximo 100 caracteres");

            RuleFor(cliente => cliente.CNPJ)
                .NotEmpty()
                .WithMessage("CNPJ é obrigatório")
                .Length(14)
                .WithMessage("CNPJ deve ter 14 caracteres");

            RuleFor(cliente => cliente.Endereco)
                .NotEmpty()
                .WithMessage("Endereço é obrigatório")
                .MaximumLength(100)
                .WithMessage("Endereço deve ter no máximo 100 caracteres");

            RuleFor(cliente => cliente.Telefone)
                .NotEmpty()
                .WithMessage("Telefone é obrigatório")
                .Length(13)
                .WithMessage("Telefone deve ter 13 caracteres");
        }
    }
}
