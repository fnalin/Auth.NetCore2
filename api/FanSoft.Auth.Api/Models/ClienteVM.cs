using System;
using System.ComponentModel.DataAnnotations;

namespace FanSoft.Auth.Api.Models
{
    public class ClienteVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="O Nome é obrigatório")]
        [StringLength(100,ErrorMessage ="Informe um nome com até 100 caracteres")]
        public string Nome { get; set; }

        public DateTime Nascimento { get; set; }


    }
}
