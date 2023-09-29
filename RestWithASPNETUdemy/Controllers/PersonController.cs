using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Models;
using RestWithASPNETUdemy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        

        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _PersonService;

         public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _PersonService = personService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _PersonService.FindById(id);
           return person == null ? NotFound("Usuário não localizado") : Ok(person);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var person = _PersonService.FindAll();
            return person.Any() ? Ok(person) : NotFound("O banco de dados está vazio");
        }
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Usuário vazio");
            }

            _PersonService.Create(person);
            return Ok(person);
        }
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var findId = _PersonService.FindById(person.Id);

            if (person == null || findId == null)
            {
                return BadRequest("Usuário vazio");
            }
            return Ok(_PersonService.Update(findId,person));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _PersonService.Delete(id);
            return NoContent();
        }
    }
}
