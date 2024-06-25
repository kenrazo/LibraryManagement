using AutoMapper;
using LibraryManagement.Application.Mapping;
namespace LibraryManagement.Application.Books.Common
{
    public class BookModel : IMapFrom<Domain.Books.Book>
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public string ISBN { get; set; }


        public virtual void Mapping(Profile mapper)
        {
            mapper.CreateMap<Domain.Books.Book, BookModel>();
        }
    }
}
