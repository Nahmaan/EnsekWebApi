using System.Web.Http;
using System.Web.Mvc;

namespace EnsekWebApi.Controllers
{
    public class AccountController : Controller
    {
        public HttpConfiguration Configuration { get; private set; }

        public AccountController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public AccountController(HttpConfiguration config)
        {
            Configuration = config;
        }

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
    }
}