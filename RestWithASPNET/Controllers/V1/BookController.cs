using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Data.DTO.V1;
using RestWithASPNET.Services;

namespace RestWithASPNET.Controllers.V1
{
    [Route("api/[controller]/v1")]
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
        [ProducesResponseType(200, Type = typeof(List<BookDTO>))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all books");
            Response.Headers.Append("X-API-Deprecated", "true");
            Response.Headers.Append("X-API-Deprecated-Date", "2026-11-03");
            return Ok(_bookService.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching book with ID: {id}", id);
            var Boook = _bookService.FindById(id);
            if (Boook == null)
            {
                _logger.LogWarning("Book with ID {id} not found", id);
                return NotFound();
            }
            return Ok(Boook);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] BookDTO book)
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
        [ProducesResponseType(200, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Put([FromBody] BookDTO book)
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
        [ProducesResponseType(204, Type = typeof(BookDTO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting Book with id: {id}", id);
            _bookService.Delete(id);
            _logger.LogDebug("Book with ID {id} deleted successfully", id);
            return NoContent();
        }
    }
}
