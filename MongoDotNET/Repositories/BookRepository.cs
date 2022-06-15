using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDotNET.Models;
using MongoDotNET.Repositories.Interfaces;
using MongoDotNET.Settings;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MongoDotNET.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly MongoContext _context;
        public BookRepository(IOptions<MongoDBSettings> settings)
        {
            _context = new MongoContext(settings);
        }
        public async Task<Book> CreateBook(Book item)
        {
            await _context.Books.InsertOneAsync(item);
            return item;
        }

        public async Task<bool> DeleteBook(int id)
        {
            var filter = Builders<Book>.Filter.Eq("Id", id);
            var deleteResult = await _context.Books.DeleteOneAsync(filter);
            return deleteResult.DeletedCount > 0;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books
                    .Find(_ => true).ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {
            return await _context.Books.Find(book => book.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Book> UpdateBook(Book item)
        {
            await _context.Books.ReplaceOneAsync(book => book.Id == item.Id, item);
            return item;
        }
    }
}
