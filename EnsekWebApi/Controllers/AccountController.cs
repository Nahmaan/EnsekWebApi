using System.Web.Http;
using System.Web.Mvc;
using EnsekDataAccess.Repository;
using EnsekServices.Services;

namespace EnsekWebApi.Controllers
{
    [System.Web.Http.RoutePrefix("account")]
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        private readonly MeterService _meterService;

        public AccountController()
        {
            var accountRepository = new AccountRepository();
            _accountService = new AccountService(accountRepository);
            var meterRepository = new MeterRepository();
            _meterService = new MeterService(meterRepository);
        }

        // GET: Account
        public ActionResult Index()
        {
            var accounts = _accountService.GetAllAccounts();
            return View(accounts);
        }
    }
}