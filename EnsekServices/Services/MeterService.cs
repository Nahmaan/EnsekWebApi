using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsekDataAccess.Models;
using EnsekDataAccess.Repository;
using EnsekServices.Interfaces;

namespace EnsekServices.Services
{
    public class MeterService : IMeterService
    {
        private readonly MeterRepository _meterRepository;

        public MeterService(MeterRepository meterRepository)
        {
            _meterRepository = meterRepository;
        }


        public IEnumerable<MeterReading> GetAllMeterReadings()
        {
            return _meterRepository.GetAllMeterReadings();
        }

        public string UploadMeterReadings(string path)
        {
            return _meterRepository.UploadMeterReadings(path);
        }
    }
}
