using System.Web.Http;
using System.Web.Mvc;
using EnsekDataAccess.Repository;
using EnsekServices.Services;

namespace EnsekWebApi.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService _accountService;
        private readonly AccountRepository _accountRepository;

        public AccountController()
        {
            _accountRepository = new AccountRepository();
            _accountService = new AccountService(_accountRepository);
        }

        // GET: Account
        public ActionResult Index()
        {
            var accounts = _accountRepository.GetAllAccounts();
            return View();
        }
    }
}