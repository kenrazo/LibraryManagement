using AutoMapper;
using LibraryManagement.Application.Abstractions.Messaging;
using LibraryManagement.Application.Books.Queries.Common;
using LibraryManagement.Domain.Abstractions;
using LibraryManagement.Domain.Books;

namespace LibraryManagement.Application.Books.Queries.GetBooks
{
    public class GetBooksQueryHandler : IQueryHandler<GetBooksQuery, GetBooksResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Result<GetBooksResponse>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            var result = new GetBooksResponse();

            var books = await _bookRepository.GetAllAsync();

            result.Datas = _mapper.Map<List<BookResponse>>(books);

            return result;
        }
    }
}
