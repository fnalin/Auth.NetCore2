using FanSoft.Auth.Api.Models;
using FanSoft.Auth.Domain.Contracts.Data;
using FanSoft.Auth.Domain.Contracts.Repositories;
using FanSoft.Auth.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FanSoft.Auth.Api.Controllers
{
    [Route("api/v1/clientes")]
    [Authorize("Bearer")]
    public class ClientesController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        public ClientesController(IClienteRepository clienteRepository, IUnitOfWork uow)
            :base(uow)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var data = await _clienteRepository.GetAsync();
            return Ok(data);
        }

        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _clienteRepository.GetAsync(id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClienteVM model)
        {
            if (ModelState.IsValid)
            {
                var cliente = new Cliente(model.Nome, model.Nascimento);
                _clienteRepository.Add(cliente);


                if (!await this.Commit())
                    return StatusCode(500);

                return CreatedAtRoute("GetCliente", new { id = cliente.Id }, new
                {
                    id = cliente.Id,
                    nome = cliente.Nome,
                    nascimento = cliente.Nascimento
                });
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]ClienteVM model)
        {
            var cliente = await _clienteRepository.GetAsync(id);

            if (cliente == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                cliente.Update(model.Nome, model.Nascimento);
                if (!await this.Commit())
                    return StatusCode(500);

                return NoContent();
            }


            return BadRequest(ModelState);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var cliente = await _clienteRepository.GetAsync(id);

            if (cliente == null)
                return NotFound();

            _clienteRepository.Del(cliente);

            if (!await this.Commit())
                return StatusCode(500);

            return new NoContentResult();
        }

    }
}
