using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Models;
using System;
using System.Linq;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:ApiVersion}")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookBusiness _BookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)
        {
            _logger = logger;
            _BookBusiness = bookBusiness;
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _BookBusiness.FindById(id);
            return person == null ? NotFound("Livro não localizado") : Ok(person);
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var book = _BookBusiness.FindAll();
            return book.Any() ? Ok(book) : NotFound("O banco de dados está vazio");
        }
        [HttpPost]
        public IActionResult Post([FromBody] Book book )
        {
            try
            {
                if (book == null)
                {
                    return BadRequest("Livro vazio");
                }

                _BookBusiness.Create(book);
                return Ok(book);
            }
            catch (Exception erro)
            {

                return BadRequest("Erro ao criar o livro no banco" + erro);
            }

        }
        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            var findId = _BookBusiness.FindById(book.Id);

            if (book == null || findId == null)
            {
                return BadRequest("Livro vazio");
            }
            return Ok(_BookBusiness.Update(findId, book));
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _BookBusiness.Delete(id);
                return NoContent();
            }
            catch (Exception erro)
            {

                return BadRequest("Erro na deleção do livro: \nDetalhes: " + erro.Message);
            }

        }
    }
}
