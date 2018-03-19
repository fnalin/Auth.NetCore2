using FanSoft.Auth.Domain.Entities;
using System.Threading.Tasks;

namespace FanSoft.Auth.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetByEmailAsync(string email);
        Usuario GetByEmail(string email);
    }
}
