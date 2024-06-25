using AutoMapper;
using LibraryManagement.Application.Books.Common;

namespace LibraryManagement.Application.Books.Commands.BorrowBook
{
    public class BorrowBookResponse : BookModel
    {
        public int Id { get; set; }

        public bool IsBorrowed { get; set; }

        public override void Mapping(Profile mapper)
        {
            mapper.CreateMap<Domain.Books.Book, BorrowBookResponse>();
        }
    }
}
