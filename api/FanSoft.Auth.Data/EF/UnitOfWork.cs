using FanSoft.Auth.Domain.Contracts.Data;
using System.Threading.Tasks;

namespace FanSoft.Auth.Data.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FanSoftAuthDataContext _context;

        public UnitOfWork(FanSoftAuthDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void RollBack()
        {
            return;
        }
    }
}
