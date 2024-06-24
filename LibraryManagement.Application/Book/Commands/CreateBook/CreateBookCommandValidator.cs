using FluentValidation;

namespace LibraryManagement.Application.Book.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(m => m.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(m => m.ISBN)
                .MaximumLength(150);

            RuleFor(m => m.Author)
                .NotNull()
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
