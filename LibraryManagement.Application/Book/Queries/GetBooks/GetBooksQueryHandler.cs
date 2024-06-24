using AutoMapper;
using LibraryManagement.Application.Abstractions.Messaging;
using LibraryManagement.Domain.Abstractions;
using LibraryManagement.Domain.Books;

namespace LibraryManagement.Application.Book.Queries.GetBooks
{
    public class GetBooksQueryHandler : IQueryHandler<GetBooksQuery, IEnumerable<GetBooksResponse>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<GetBooksResponse>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var result = new List<GetBooksResponse>();

            var books = await _bookRepository.GetAllAsync();

            result = _mapper.Map<List<GetBooksResponse>>(books);

            return result;
        }
    }
}
