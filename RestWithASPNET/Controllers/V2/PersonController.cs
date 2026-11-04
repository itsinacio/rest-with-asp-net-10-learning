using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Data.DTO.V2;
using RestWithASPNET.Services.Impl;

namespace RestWithASPNET.Controllers.V2
{
    [Route("api/[controller]/v2")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private PersonServiceImplV2 _personService;
        private readonly ILogger<PersonController> _logger;
        public PersonController(PersonServiceImplV2 personServices, ILogger<PersonController> logger)
        {
            _personService = personServices;
            _logger = logger;
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
    }
}
