using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebForum.Domain.Entities;

namespace WebForum.Domain.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
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
