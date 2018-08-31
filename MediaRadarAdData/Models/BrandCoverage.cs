using MediaRadarAdData.AdDataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediaRadarAdData.Models
{
    public class BrandCoverage
    {
        public Brand Brand { get; set; }
        public decimal TotalCoverage { get; set; }
    }
}