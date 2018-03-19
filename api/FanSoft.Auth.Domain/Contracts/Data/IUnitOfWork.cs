using System.Threading.Tasks;

namespace FanSoft.Auth.Domain.Contracts.Data
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void RollBack();
    }
}
