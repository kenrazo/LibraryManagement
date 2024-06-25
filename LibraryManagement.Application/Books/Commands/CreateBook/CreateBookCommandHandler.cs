using AutoMapper;
using LibraryManagement.Application.Abstractions.Messaging;
using LibraryManagement.Domain.Abstractions;
using LibraryManagement.Domain.Books;

namespace LibraryManagement.Application.Books.Commands.CreateBook
{
    public class CreateBookCommandHandler : ICommandHandler<CreateBookCommand, CreateBookResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Result<CreateBookResponse>> Handle(CreateBookCommand request,
            CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetByTitleAndAuthor(request.Title, request.Author);
            if (book is not null)
            {
                return Result.Failure<CreateBookResponse>(BookErrors.BookAlreadyExist(request.Title, request.Author));
            }

            var newBook = Domain.Books.Book.CreateNewBook(request.Title, request.Author, request.ISBN);
            var result = await _bookRepository.InsertAsync(newBook);

            return _mapper.Map<CreateBookResponse>(result);
        }
    }
}
