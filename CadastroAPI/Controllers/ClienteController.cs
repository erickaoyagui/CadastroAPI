using CadastroAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CadastroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private static List<Cliente> clientes = new List<Cliente>();
        // GET: api/<ClienteController>
        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return clientes;
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Cliente cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente != null)
            {
                return Ok(cliente);
            }
            return NotFound();
        }

        // POST api/<ClienteController>
        [HttpPost]
        public void Post([FromBody] Cliente cliente)
        {
            clientes.Add(cliente);
        }

        // PATCH api/<ClienteController>/5
        [HttpPatch("{id}")]
        public IActionResult Patch(int id)
        {
            Cliente cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);
            return NotFound();
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            Cliente cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);
            if (cliente != null)
            {
            }
            return NotFound();
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Cliente cliente = clientes.FirstOrDefault(cliente => cliente.Id == id);
            return NotFound();
        }

    }
}
