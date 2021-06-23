using FluentValidation;
using System;
using Domain.Entities;

namespace Domain.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(Validator)
                .NotNull()
                .WithMessage("O id não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O id não pode ser um Guid vazio");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O campo não pode estar vazio.")
                .WithMessage("O nome não pode conter caracteres especiais e/ou números")
                .MaximumLength(150)
                .WithMessage("O tamanho máximo permitido é de 150 caracteres");


            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email cannot be null")
                .NotEmpty()
                .WithMessage("Email cannot be empty")
                .EmailAddress()
                .WithMessage("Invalid e-mail format")
                .MaximumLength(200);

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("A senha não pode ser nula.")
                .NotEmpty()
                .WithMessage("O campo não pode estar vazio.")
                .MinimumLength(8)
                .WithMessage("Password should not be less than 8 character");

        }

        public bool Validator(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
