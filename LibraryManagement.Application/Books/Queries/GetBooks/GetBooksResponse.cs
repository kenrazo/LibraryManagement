using AutoMapper;
using LibraryManagement.Application.Books.Common;

namespace LibraryManagement.Application.Books.Queries.GetBooks
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
