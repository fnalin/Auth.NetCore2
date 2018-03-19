using FanSoft.Auth.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FanSoft.Auth.Data.EF
{
    public class DbInitialize
    {
        public static void Initialize(FanSoftAuthDataContext context)
        {
            context.Database.EnsureCreated();
            var dbClientes = context.Set<Cliente>();
            if (!dbClientes.Any())
            {
                var clientes = new List<Cliente> {
                    new Cliente("José Carlos da Silva",new DateTime(1958,08,21)),
                    new Cliente("Maria José Pereira", new DateTime(1969,9,12))
                };

                dbClientes.AddRange(clientes);
                context.SaveChanges();
            }


            var dbUsuarios = context.Set<Usuario>();
            if (!dbUsuarios.Any())
            {
                var usuarios = new List<Usuario> {
                    new Usuario("Fabiano Nalin","fabiano.nalin@gmail.com","123456"),
                    new Usuario("Priscila Nalin", "pri@gmail.com","789012")
                };

                dbUsuarios.AddRange(usuarios);
                context.SaveChanges();
            }
        }
    }
}
