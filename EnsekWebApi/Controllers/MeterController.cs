using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnsekDataAccess.Repository;
using EnsekServices.Services;
using EnsekWebApi.ViewModels;

namespace EnsekWebApi.Controllers
{
    [System.Web.Http.RoutePrefix("meter")]
    public class MeterController : Controller
    {
        private readonly AccountService _accountService;
        private readonly MeterService _meterService;
        private readonly MeterRepository _meterRepository;

        public MeterController()
        {
            var accountRepository = new AccountRepository();
            _accountService = new AccountService(accountRepository);
            _meterRepository = new MeterRepository();
            _meterService = new MeterService(_meterRepository);
        }


        [System.Web.Http.Route("meter-reading-uploads")]
        [System.Web.Http.HttpPost]
        public ActionResult Index()
        {
            var meterViewModel = new MeterViewModel();
            meterViewModel.Result = _meterService.UploadMeterReadings(@"C:\Users\Nahmaan\source\repos\EnsekWebApi\EnsekWebApi\Meter_Reading.csv");
            meterViewModel.MeterReadings = _meterRepository.GetAllMeterReadings().ToList();
            return View();
        }
    }
}