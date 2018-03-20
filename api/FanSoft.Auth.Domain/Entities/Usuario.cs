using FanSoft.Auth.Domain.Helpers;

namespace FanSoft.Auth.Domain.Entities
{
    public class Usuario:Entity
    {
        public Usuario(string nome, string email, string senha)
        {
            Email = email;
            Nome = nome;
            Senha = senha.Encrypt();
        }

        protected Usuario(){}

        public string Email { get; private set; }
        public string Nome { get; private set; }
        public string Senha { get; private set; }

        public void Update(string nome, string email, string senha)
        {
            Email = email;
            Nome = nome;
            Senha = senha.Encrypt();
        }

        public bool IsAuthenticate(string senha)
        {
            return Senha == senha;
        }
    }
}
