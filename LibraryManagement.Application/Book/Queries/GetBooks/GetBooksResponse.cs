using AutoMapper;
using LibraryManagement.Application.Book.Common;

namespace LibraryManagement.Application.Book.Queries.GetBooks
{
    public class GetBooksResponse : BookModel
    {
        public int Id { get; set; }

        public bool IsBorrowed { get; set; }
        //public List<BookResponse> Datas { get; set; }

        public override void Mapping(Profile mapper)
        {
            mapper.CreateMap<Domain.Books.Book, GetBooksResponse>();
        }
    }
}
