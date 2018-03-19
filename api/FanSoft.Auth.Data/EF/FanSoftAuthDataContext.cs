using FanSoft.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FanSoft.Auth.Data.EF
{
    public class FanSoftAuthDataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public FanSoftAuthDataContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("FanSoftAuthConn"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.UsuarioMap());
            modelBuilder.ApplyConfiguration(new Maps.ClienteMap());

        }
    }
}
