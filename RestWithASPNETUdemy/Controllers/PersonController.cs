using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Models;
using System;
using System.Linq;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonBusiness _PersonBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)
        {
            _logger = logger;
            _PersonBusiness = personBusiness;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _PersonBusiness.FindById(id);
            return person == null ? NotFound("Usuário não localizado") : Ok(person);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var person = _PersonBusiness.FindAll();
            return person.Any() ? Ok(person) : NotFound("O banco de dados está vazio");
        }
        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            try
            {
                if (person == null)
                {
                    return BadRequest("Usuário vazio");
                }

                _PersonBusiness.Create(person);
                return Ok(person);
            }
            catch (Exception erro)
            {

                return BadRequest("Erro ao criar o usuário no banco" + erro);
            }

        }
        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            var findId = _PersonBusiness.FindById(person.Id);

            if (person == null || findId == null)
            {
                return BadRequest("Usuário vazio");
            }
            return Ok(_PersonBusiness.Update(findId, person));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _PersonBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest("Erro na deleção do usuário: \nDetalhes: " + erro.Message);
            }

        }
    }
}
