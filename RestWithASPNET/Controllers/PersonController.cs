using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Model;
using RestWithASPNET.Services;

namespace RestWithASPNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IPersonServices _personService;

        public PersonController(IPersonServices personServices)
        {
            _personService = personServices;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if(person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var createPerson = _personService.Create(person);
            if(createPerson == null) return NotFound();
            return Ok(createPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var createPerson = _personService.Update(person);
            if(createPerson == null) return NotFound();
            return Ok(createPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
