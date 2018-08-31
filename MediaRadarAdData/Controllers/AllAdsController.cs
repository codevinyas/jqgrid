
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

using MediaRadarAdData.Business;
using MediaRadarAdData.AdDataService;

namespace MediaRadarAdData.Controllers
{
    /// <summary>
    /// All Ads controller
    /// </summary>
    public class AllAdsController : AdsBaseController
    {       
        public ViewResult AllAds()
        {
            return View();
        }

        /// <summary>
        /// Gets all the ads for the given date range
        /// </summary>
        /// <param name="sidx">Sort Index</param>
        /// <param name="sord">Sort Order</param>
        /// <param name="page">Page Number</param>
        /// <param name="rows">No of rows per page</param>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns></returns>        
        public JsonResult GetAllAds(string sidx, string sord, int page, int rows, DateTime startDate, DateTime endDate)
        {
            var adData = AdDataManager.GetAllAdData(startDate, endDate);
            return GetJsonData<Ad>(sidx, sord, page, rows, adData);            
        }       
    }
}