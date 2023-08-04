using CadastroAPI.Domain.Entities;
using CadastroAPI.Domain.Interfaces;
using CadastroAPI.Infrastructure.Data;
using CadastroAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository repository;
        public ClienteController(IClienteRepository repository)
        {
            this.repository = repository;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Cliente> clientes = repository.GetAll();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Cliente cliente = repository.GetById(id);
                if (cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                repository.Add(cliente);
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // PATCH api/<ClienteController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody] Cliente cliente)
        {
            try
            {
                repository.Update(cliente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                repository.Update(cliente);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                repository.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}
