using FanSoft.Auth.Api.Models;
using FanSoft.Auth.Domain.Contracts.Repositories;
using FanSoft.Auth.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace FanSoft.Auth.Api.Controllers
{
    [Route("api/v1/security")]
    public class SecurityController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private Usuario _usuario;

        public SecurityController(IUsuarioRepository usuarioRepo, SigningConfigurations signingConfigurations, TokenConfigurations tokenConfigurations)
        {
            _usuarioRepo = usuarioRepo;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginVM data)
        {
            var identity = await GetClaims(data);
            if (identity == null)
            {
                return Unauthorized();
            }

            var dataCriacao = DateTime.Now;
            var dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return Ok(
                new
                    {
                        authenticated = true,
                        created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                        expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                        accessToken = token,
                        message = "OK"
                    }
                );
        }


        private Task<ClaimsIdentity> GetClaims(LoginVM data)
        {
            var usuario = _usuarioRepo.GetByEmail(data.Email);

            if (usuario == null)
                return Task.FromResult<ClaimsIdentity>(null);

            if (!usuario.IsAuthenticate(data.Senha))
                return Task.FromResult<ClaimsIdentity>(null);

            _usuario = usuario;

            return Task.FromResult(new ClaimsIdentity(
                new GenericIdentity(usuario.Email, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, data.Email)
                }));
        }

    }
}
