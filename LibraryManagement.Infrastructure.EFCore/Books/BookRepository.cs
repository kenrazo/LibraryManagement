using LibraryManagement.Domain.Books;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.EFCore.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryManagementContext _context;

        public BookRepository(LibraryManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();

        public async Task<Book?> GetAsync(int id) => await _context.Books.FindAsync(id);

        public async Task<Book> InsertAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
