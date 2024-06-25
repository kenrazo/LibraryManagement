using FluentValidation;

namespace LibraryManagement.Application.Books.Commands.BorrowBook
{
    public class BorrowBookCommandValidator : AbstractValidator<BorrowBookCommand>
    {
        public BorrowBookCommandValidator()
        {
            RuleFor(m => m.Id)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}
