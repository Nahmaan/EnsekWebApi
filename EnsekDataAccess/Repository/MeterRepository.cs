using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EnsekDataAccess.Interfaces;
using EnsekDataAccess.Models;

namespace EnsekDataAccess.Repository
{
    public class MeterRepository : IMeterRespository
    {
        private readonly EnsekEntities _ensekEntities;

        public MeterRepository()
        {
            _ensekEntities = new EnsekEntities();
        }

        public IEnumerable<MeterReading> GetAllMeterReadings()
        {
            return _ensekEntities.MeterReadings.ToList();
        }

        public string UploadMeterReadings(string path)
        {
            if(string.IsNullOrEmpty(path)) return string.Empty;

            var failures = 0;
            var successful = 0;

            using (var sr = new StreamReader(path))
            {
                // read first line and ignore - headers
                var headers = sr.ReadLine()?.Split(',');
                if (headers == null) return string.Empty;
                while (!sr.EndOfStream)
                {
                    var row = sr.ReadLine()?.Split(',');
                    if (!ValidateMeterReadings(row))
                    {
                        failures++;
                        continue;
                    }

                    var accountId = Convert.ToInt32(row[0]);
                    var meterReadings = _ensekEntities.MeterReadings.ToList().Where(x => x.AccountId == accountId);
                    var account = _ensekEntities.Accounts.FirstOrDefault(x => x.AccountId == accountId);
                    if (account == null)
                    {
                        failures++;
                        continue;
                    }

                    var meterReading = new MeterReading
                    {
                        Account = account,
                        MeterReadingDateTime = DateTime.Parse(row?[1]),
                        MeterReadValue = Convert.ToInt32(row?[2])
                    };

                    var duplicate = meterReadings.Where(x => x.Account == meterReading.Account && x.MeterReadingDateTime == meterReading.MeterReadingDateTime && x.MeterReadValue == meterReading.MeterReadValue);
                    if (duplicate.Any())
                    {
                        failures++;
                        continue;
                    }

                    successful++;
                    _ensekEntities.MeterReadings.Add(meterReading);
                    _ensekEntities.SaveChanges();
                }
            }

            if (successful == 0)
                return "No meter readings added due to duplicate or invalid data";

            return $@"Successful meter readings: {successful}. Failed meter readings: {failures}";
        }

        private static bool ValidateMeterReadings(string[] row)
        {
            if (string.IsNullOrEmpty(row[0]))
                return false;

            if (row[2].Length > 5)
                return false;

            if (string.IsNullOrEmpty(row[2]))
                return false;

            foreach (var character in row[2])
            {
                if (!char.IsNumber(character))
                    return false;
            }

            return true;
        }
    }
}
