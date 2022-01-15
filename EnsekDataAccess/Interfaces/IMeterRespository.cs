using EnsekDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnsekDataAccess.Interfaces
{
    public interface IMeterRespository
    {
        IEnumerable<MeterReading> GetAllMeterReadings();
        string UploadMeterReadings(string path);
    }
}
