using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MediaRadarAdData.Business;
using MediaRadarAdData.AdDataService;

namespace MediaRadarAdData.Controllers
{
    /// <summary>
    /// Top 5 Ads controller
    /// </summary>
    public class Top5AdsController : AdsBaseController
    {
        public ActionResult Top5Ads()
        {
            return View();
        }

        /// <summary>
        /// Get the top 5 ads with highest coverage for the given date range
        /// </summary>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns></returns>
        public JsonResult GetTop5Ads(DateTime startDate, DateTime endDate)
        {
            var adData = AdDataManager.GetTop5Ads(startDate, endDate);
            return GetBasicJsonData<Ad>(adData);
        }
    }
}