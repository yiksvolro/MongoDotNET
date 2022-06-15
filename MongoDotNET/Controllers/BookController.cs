using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDotNET.Models;
using MongoDotNET.Repositories.Interfaces;
using System.Threading.Tasks;

namespace MongoDotNET.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(Book book)
        {
            return Ok(await _bookRepository.CreateBook(book));
        }
        [HttpGet]
        public async Task<IActionResult> GetBook(int id)
        {
            return Ok(await _bookRepository.GetBook(id));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            return Ok(await _bookRepository.GetAllBooks());
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            return Ok(await _bookRepository.UpdateBook(book));
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int id)
        {
            return Ok(await _bookRepository.DeleteBook(id));
        }
    }
}
