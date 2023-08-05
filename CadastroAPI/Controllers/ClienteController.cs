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
        private IClienteRepository _repository;
        private readonly ILogger<ClienteController> _logger;
        public ClienteController(IClienteRepository repository, ILogger<ClienteController> logger)
        {
            _repository = repository;
            _logger = logger;
        }
        // GET: api/<ClienteController>
        /// <summary>
        /// Obtém a lista de todos os clientes.
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso retorne a lista normalmente</response>
        /// <response code="500">Caso retorne erro interno</response>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<Cliente> clientes = _repository.GetAll();
                _logger.LogInformation("Chamada GetAll");
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro interno: {ex.Message}");
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // GET api/<ClienteController>/
        /// <summary>
        /// Obtém os detalhes de um cliente pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser obtido</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso encontre o cliente no id especificado</response>
        /// <response code="404">Caso não encontre o cliente no id especificado</response>
        /// <response code="500">Caso retorne erro interno</response>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                Cliente cliente = _repository.GetById(id);
                if (cliente == null)
                {
                    _logger.LogWarning($"Chamada Get NotFound: {id}");
                    return NotFound();
                }
                _logger.LogInformation($"Chamada Get Retornando Id: {cliente.Id}");
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro interno: {ex.Message}");
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        /// <summary>
        /// Cria um novo cliente.
        /// </summary>
        /// <param name="cliente">Detalhes do cliente a serem criados</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso a inserção seja feita com sucesso</response>
        /// <response code="500">Caso retorne erro interno</response>
        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            try
            {
                _repository.Add(cliente);
                _logger.LogInformation($"Chamada Post Inserido");
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro interno: {ex.Message}");
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // PATCH api/<ClienteController>/
        /// <summary>
        /// Atualiza os detalhes de um cliente pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser atualizado</param>
        /// <param name="cliente">Detalhes atualizados do cliente</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso a atualização seja feita com sucesso</response>
        /// <response code="500">Caso retorne erro interno</response>
        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody] Cliente cliente)
        {
            try
            {
                _repository.Update(cliente);
                _logger.LogInformation($"Chamada Patch atualizado Cliente Id: {cliente.Id}");
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro interno: {ex.Message}");
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

        // DELETE api/<ClienteController>/
        /// <summary>
        /// Exclui um cliente pelo ID.
        /// </summary>
        /// <param name="id">ID do cliente a ser excluído</param>
        ///<returns>IActionResult</returns>
        /// <response code="204">Caso a remoção seja feita com sucesso</response>
        /// <response code="404">Caso a remoção seja feita com sucesso</response>
        /// <response code="500">Caso retorne erro interno</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Cliente cliente = _repository.GetById(id);
                if (cliente == null)
                {
                    _logger.LogWarning($"Chamada Delete NotFound: {id}");
                    return NotFound();
                }
                else
                {
                    _repository.Delete(id);
                    _logger.LogInformation($"Chamada Delete removido Cliente Id: {id}");
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro interno: {ex.Message}");
                return StatusCode(500, $"Erro interno: {ex.Message}");
            }
        }

    }
}
