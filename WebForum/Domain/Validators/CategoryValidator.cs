using FluentValidation;
using System;
using Domain.Entities;

namespace Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(Validator)
                .NotNull()
                .WithMessage("Id cannot be null")
                .NotEqual(new Guid())
                .WithMessage("Id cannot be empty");

            RuleFor(x => x.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("Name cannot be null.")
                .NotEmpty()
                .WithMessage("O campo não pode estar vazio.")
                .MaximumLength(60)
                .WithMessage("O tamanho máximo permitido é de 60 caracteres");
        }
        public bool Validator(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
