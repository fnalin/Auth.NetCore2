using System.ComponentModel.DataAnnotations;

namespace FanSoft.Auth.Api.Models
{
    public class UsuarioVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Informe um nome com até 100 caracteres")]
        public string Nome { get; set; }

        [RegularExpression(@"([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)", ErrorMessage = "Email inválido")]
        [Required(ErrorMessage = "O Email é obrigatório")]
        [StringLength(100, ErrorMessage = "Informe um email com até 100 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatório")]
        [StringLength(50, ErrorMessage = "Informe ums senha com até 100 caracteres")]
        public string Senha { get; set; }

    }
}
