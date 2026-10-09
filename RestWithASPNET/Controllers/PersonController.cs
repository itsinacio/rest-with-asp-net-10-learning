using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Data.DTO;
using RestWithASPNET.Model;
using RestWithASPNET.Services;

namespace RestWithASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonServices _personService;
        private readonly ILogger<PersonController> _logger;
        public PersonController(IPersonServices personServices, ILogger<PersonController> logger)
        {
            _personService = personServices;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all persons");
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            _logger.LogInformation("Fetching person with ID: {id}", id);
            var person = _personService.FindById(id);
            if (person == null)
            {
                _logger.LogWarning("Person with ID {id} not found", id);
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Create new person: {firstName}", person.FirstName);
            var createPerson = _personService.Create(person);
            if (createPerson == null)
            {
                _logger.LogError("Failed to create person with name {firstName}", person.FirstName);
                return NotFound();
            }
            return Ok(createPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] PersonDTO person)
        {
            _logger.LogInformation("Updating person with id: {id}", person.Id);
            var createPerson = _personService.Update(person);
            if (createPerson == null)
            {
                _logger.LogError("Failed to update person with id: {id}", person.Id);
                return NotFound();
            }
            _logger.LogDebug("Person Updated sucessfully: {firstName}",createPerson.FirstName);
            return Ok(createPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _logger.LogInformation("Deleting person with id: {id}", id);
            _personService.Delete(id);
            _logger.LogDebug("Person with ID {id} deleted successfully",id);
            return NoContent();
        }
    }
}
