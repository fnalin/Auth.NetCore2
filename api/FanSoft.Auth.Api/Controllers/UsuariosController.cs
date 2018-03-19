using FanSoft.Auth.Api.Models;
using FanSoft.Auth.Domain.Contracts.Data;
using FanSoft.Auth.Domain.Contracts.Repositories;
using FanSoft.Auth.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace FanSoft.Auth.Api.Controllers
{
    [Route("api/v1/usuarios")]
    public class UsuariosController:BaseController
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository usuarioRepository, IUnitOfWork uow)
            : base(uow)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            var data = await _usuarioRepository.GetAsync();
            return Ok(data.Select(d=>new {
                id = d.Id,
                nome = d.Nome,
                email = d.Email,
                dataCriacao = d.DataCricacao
            }));
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _usuarioRepository.GetAsync(id);

            if (data == null)
                return NotFound();

            return Ok(new {
                id = data.Id,
                nome = data.Nome,
                email = data.Email,
                dataCriacao = data.DataCricacao
            });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UsuarioVM model)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario(model.Nome, model.Email, model.Senha);
                _usuarioRepository.Add(usuario);


                if (!await this.Commit())
                    return StatusCode(500);

                return CreatedAtRoute("GetUsuario", new { id = usuario.Id }, new
                {
                    id = usuario.Id,
                    nome = usuario.Nome,
                    email = usuario.Email,
                    dataCriacao = usuario.DataCricacao
                });
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]UsuarioVM model)
        {
            var usuario = await _usuarioRepository.GetAsync(id);

            if (usuario == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                usuario.Update(model.Nome, model.Email, model.Senha);
                if (!await this.Commit())
                    return StatusCode(500);

                return NoContent();
            }


            return BadRequest(ModelState);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var usuario = await _usuarioRepository.GetAsync(id);

            if (usuario == null)
                return NotFound();

            _usuarioRepository.Del(usuario);

            if (!await this.Commit())
                return StatusCode(500);

            return new NoContentResult();
        }
    }
}
