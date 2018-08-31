using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MediaRadarAdData.Models;
using MediaRadarAdData.Business;
using MediaRadarAdData.AdDataService;

namespace MediaRadarAdData.Controllers
{
    /// <summary>
    /// Top 5 brands controller
    /// </summary>
    public class Top5BrandsController : AdsBaseController
    {
        public ActionResult Top5Brands()
        {
            return View();
        }

        /// <summary>
        /// Get the top 5 brands with highest coverage for the given date range
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns></returns>
        public JsonResult GetTop5Brands(DateTime startDate, DateTime endDate)
        {
            var adData = AdDataManager.GetTop5Brands(startDate, endDate);
            return GetBasicJsonData<BrandCoverage>(adData);
        }
    }
}