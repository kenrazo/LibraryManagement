using FluentValidation;

namespace LibraryManagement.Application.Books.Commands.ReturnBook
{
    public class ReturnBookCommandValidator : AbstractValidator<ReturnBookCommand>
    {
        public ReturnBookCommandValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
