using FanSoft.Auth.Domain.Contracts.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FanSoft.Auth.Api.Controllers
{
    public class BaseController : Controller
    {
        private readonly IUnitOfWork _uow;
        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        protected async Task<bool> Commit()
        {
            try
            {
                await _uow.CommitAsync();
                return true;
            }
            catch
            {
                //log
                return false;
            }

        }

    }
}
