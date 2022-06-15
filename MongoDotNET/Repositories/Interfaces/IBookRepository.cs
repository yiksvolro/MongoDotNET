using MongoDotNET.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDotNET.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> CreateBook(Book item);
        Task<Book> GetBook(int id);
        Task<List<Book>> GetAllBooks();
        Task<Book> UpdateBook(Book item);
        Task<bool> DeleteBook(int id);
    }
}
