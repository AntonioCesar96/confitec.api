using Confitec.Domain.Commands;
using Confitec.Domain.Helpers;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Confitec.Domain.Validators
{
    public class UserValidator : AbstractValidator<UserCommand>
    {
        private UserCommand Command;

        public UserValidator(UserCommand command)
        {
            Command = command;
        }

        public ValidationResult ValidationResult { get; set; }

        public bool ValidateCommand()
        {
            RuleFor(p => p.Name)
                .Must(e => !string.IsNullOrEmpty(e))
                    .WithMessage("Nome é obrigatório!");

            RuleFor(p => p.Email)
                .Must(e => !string.IsNullOrEmpty(e))
                    .WithMessage("E-mail é obrigatório.")
                .Must(e => string.IsNullOrEmpty(e) || EmailHelper.Validade(e))
                    .WithMessage("E-mail está inválido.");

            RuleFor(p => p.BirthDate)
                .NotEmpty()
                    .WithMessage("Data de nascimento é obrigatória.")
                .Must(p => p.Date <= DateTime.Now.Date)
                    .WithMessage("Data de nascimento não pode ser maior que hoje.");

            RuleFor(p => p.SchoolingId)
                .GreaterThan(0)
                    .WithMessage("Escolaridade é obrigatória.");

            ValidationResult = Validate(Command);
            return ValidationResult.IsValid;
        }

        public List<string> GetErrorMessages()
        {
            return ValidationResult.Errors
                .Select(e => e.ErrorMessage)
                .ToList();
        }
    }
}
