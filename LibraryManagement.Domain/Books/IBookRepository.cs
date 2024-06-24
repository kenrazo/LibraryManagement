namespace LibraryManagement.Domain.Books
{
    public interface IBookRepository
    {
        Task<Book> GetAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> InsertAsync(Book book);
        Task<Book> UpdateAsync(Book book);
    }
}
