using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebForum.Domain.Entities;

namespace WebForum.Domain.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(Validator)
                .NotNull()
                .WithMessage("O id não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O id não pode ser um Guid vazio");

            RuleFor(x => x.Content)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O nome não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O campo não pode estar vazio.");

            RuleFor(x => x.Title)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .MaximumLength(60)
                .NotEmpty()
                .WithMessage("Cannot be empty");

        }
        public bool Validator(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
