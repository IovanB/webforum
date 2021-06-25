using FluentValidation;
using System;
using Domain.Entities;

namespace Domain.Validators
{
    public class TopicValidator : AbstractValidator<Topic>
    {
        public TopicValidator()
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
                .MaximumLength(60)
                .WithMessage("O tamanho máximo permitido é de 60 caracteres");

            RuleFor(x => x.CreatedAt)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull();

            RuleFor(x => x.Category.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(Validator)
                .WithMessage("A categoria Id não pode ser nulo.");
        }
        public bool Validator(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
