using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;
using RestWithASPNET.Services;

namespace RestWithASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookServices _bookService;
        private readonly ILogger<BookController> _logger;
        public BookController(IBookServices bookServices, ILogger<BookController> logger)
        {
            _bookService = bookServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all books");
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching book with ID: {id}", id);
            var person = _bookService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Book with ID {id} not found", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            _logger.LogInformation("Create new book: {Title}", book.Title);
            var createBook = _bookService.Create(book);
            if (createBook == null)
            {
                _logger.LogError("Failed to create book with name {Title}", book.Title);
                return NotFound();
            }
            return Ok(createBook);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            _logger.LogInformation("Updating Book with id: {id}", book.Id);
            var createBook = _bookService.Update(book);
            if (createBook == null)
            {
                _logger.LogError("Failed to update Book with id: {id}", book.Id);
                return NotFound();
            }
            _logger.LogDebug("Book Updated sucessfully: {Title}", createBook.Title);
            return Ok(createBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting Book with id: {id}", id);
            _bookService.Delete(id);
            _logger.LogDebug("Book with ID {id} deleted successfully", id);
            return NoContent();
        }
    }
}
