using AutoMapper;
using LibraryManagement.Application.Abstractions.Messaging;
using LibraryManagement.Domain.Abstractions;
using LibraryManagement.Domain.Books;

namespace LibraryManagement.Application.Book.Commands.BorrowBook
{
    public class BorrowBookCommandHandler : ICommandHandler<BorrowBookCommand, BorrowBookResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BorrowBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Result<BorrowBookResponse>> Handle(BorrowBookCommand request,
            CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.Id);

            if (book is null)
            {
                return (Result.Failure<BorrowBookResponse>(BookErrors.BookNotFound(request.Id)));
            }

            book.BarrowBook();

            var borrowedBook = await _bookRepository.UpdateAsync(book);

            return _mapper.Map<BorrowBookResponse>(borrowedBook);
        }
    }
}
