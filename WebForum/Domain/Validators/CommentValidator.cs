using FluentValidation;
using System;
using WebForum.Domain.Entities;

namespace WebForum.Domain.Validators
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

            RuleFor(x => x.Author)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("O autor não pode ser nulo.")
                .NotEmpty()
                .WithMessage("O campo não pode estar vazio.");

            RuleFor(x => x.Post)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithMessage("There must be an existent post")
                .NotEmpty()
                .WithMessage("There must be an existent post");

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
