using FanSoft.Auth.Domain.Contracts.Repositories;
using FanSoft.Auth.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace FanSoft.Auth.Data.EF.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        private readonly DbSet<Cliente> _db;
        public ClienteRepository(FanSoftAuthDataContext ctx) : base(ctx) => _db = ctx.Set<Cliente>();

        public IEnumerable GetByNome(string nome)
        {
            return _db.Where(c => c.Nome.ToLower().Contains(nome.ToLower())).AsNoTracking().ToList();
        }

        public async Task<IEnumerable> GetByNomeAsync(string nome)
        {
            return await _db.Where(c => c.Nome.ToLower().Contains(nome.ToLower())).AsNoTracking().ToListAsync();
        }
    }
}
