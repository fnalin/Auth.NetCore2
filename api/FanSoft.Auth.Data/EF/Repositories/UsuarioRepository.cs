using FanSoft.Auth.Domain.Contracts.Repositories;
using FanSoft.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoft.Auth.Data.EF.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly DbSet<Usuario> _db;
        public UsuarioRepository(FanSoftAuthDataContext ctx) : base(ctx) => _db = ctx.Set<Usuario>();

        public Usuario GetByEmail(string email)
        {
            return _db.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<Usuario> GetByEmailAsync(string email)
        {
            return await _db.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }
    }
}
