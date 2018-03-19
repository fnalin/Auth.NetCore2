using System;

namespace FanSoft.Auth.Domain.Entities
{
    public class Cliente:Entity
    {
        public Cliente(string nome, DateTime nascimento)
        {
            Nome = nome;
            Nascimento = nascimento;
        }

        protected Cliente(){}

        public string Nome { get; private set; }
        public DateTime Nascimento { get; private set; }

        public void Update(string nome, DateTime nascimento)
        {
            Nome = nome;
            Nascimento = nascimento;
        }

    }
}
