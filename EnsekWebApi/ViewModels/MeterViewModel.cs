using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnsekDataAccess.Models;
using EnsekDataAccess.Repository;

namespace EnsekWebApi.ViewModels
{
    public class MeterViewModel
    {
        private static MeterRepository _meterRepository;
        public string Result { get; set; }

        private List<MeterReading> _meterReadings;
        public List<MeterReading> MeterReadings
        {
            get => _meterReadings.ToList();
            set => _meterReadings = value.ToList();
        }

    }
}