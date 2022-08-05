using FluentValidation;
using System;
using Domain.Entities;

namespace Domain.Validators
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(Validator)
                .NotNull()
                .WithMessage("O id não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O id não pode ser um Guid vazio");

            RuleFor(x => x.UserId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O Id do autor não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O Id do autor não pode ser um Guid vazio");

            RuleFor(x => x.PostId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O Id do post não pode ser nulo.")
                .NotEqual(new Guid())
                .WithMessage("O Id do post não pode ser um Guid vazio");

            RuleFor(x => x.Content)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O comentário não pode ser nulo.")
                .MaximumLength(1000)
                .NotEmpty()
                .WithMessage("O campo não pode estar vazio.");
        }
        public bool Validator(Guid id)
        {
            return id != Guid.Empty;
        }
    }
}
