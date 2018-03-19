using FanSoft.Auth.Domain.Helpers;

namespace FanSoft.Auth.Api.Models
{
    public class LoginVM
    {
        private string _senha;

        public string Email { get; set; }
        public string Senha
        {
            get => _senha.Encrypt();
            set => _senha = value;
        }
    }
}
