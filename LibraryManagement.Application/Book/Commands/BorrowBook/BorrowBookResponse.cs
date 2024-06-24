using AutoMapper;
using LibraryManagement.Application.Book.Common;

namespace LibraryManagement.Application.Book.Commands.BorrowBook
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
