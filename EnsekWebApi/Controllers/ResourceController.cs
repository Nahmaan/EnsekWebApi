using EnsekServices.Interfaces;
using EnsekDataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EnsekDataAccess.Repository;
using EnsekServices.Services;

namespace EnsekWebApi.Controllers
{
    public class ResourceController : ApiController
    {
        private readonly IAccountService _accountService;
        private readonly IMeterService _meterService;

        public ResourceController()
        {
            var accountRepository = new AccountRepository();
            _accountService = new AccountService(accountRepository);
            var meterRepository = new MeterRepository();
            _meterService = new MeterService(meterRepository);
        }

        [Route("meter-reading-uploads")]
        [HttpPost]
        public string UploadReadings()
        {
            _accountService.GetAllAccounts();
            
            return _meterService.UploadMeterReadings(@"C:\Users\Nahmaan\source\repos\EnsekWebApi\EnsekWebApi\Meter_Reading.csv");
        }
    }
}
