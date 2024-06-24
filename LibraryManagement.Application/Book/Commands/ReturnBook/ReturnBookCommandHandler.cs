using AutoMapper;
using LibraryManagement.Application.Abstractions.Messaging;
using LibraryManagement.Domain.Abstractions;
using LibraryManagement.Domain.Books;

namespace LibraryManagement.Application.Book.Commands.ReturnBook
{
    public class ReturnBookCommandHandler : ICommandHandler<ReturnBookCommand, ReturnBookResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public ReturnBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Result<ReturnBookResponse>> Handle(ReturnBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetAsync(request.Id);

            if (book is null)
            {
                return (Result.Failure<ReturnBookResponse>(BookErrors.BookNotFound(request.Id)));
            }

            book.ReturnBook();

            var returnedBook = await _bookRepository.UpdateAsync(book);

            return _mapper.Map<ReturnBookResponse>(returnedBook);
        }
    }
}
