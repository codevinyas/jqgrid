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
    /// Ads By Coverage Controller
    /// </summary>
    public class AdsByCoverageController : AdsBaseController
    {
        #region Public Methods
        public ActionResult AdsByCoverage()
        {            
            return View();
        }

        /// <summary>
        /// Gets all the ads whose Cover position is atleast 50% for the given date range
        /// </summary>
        /// <param name="sidx">Sort Index</param>
        /// <param name="sord">Sort Order</param>
        /// <param name="page">Page Number</param>
        /// <param name="rows">No of rows per page</param>
        /// <param name="startDate">Start Date</param>
        /// <param name="endDate">End Date</param>
        /// <returns></returns>        
        public JsonResult GetAdsByCoverage(string sidx, string sord, int page, int rows, DateTime startDate, DateTime endDate)
        {
            var adData = AdDataManager.GetCoverageData(startDate, endDate);
            return GetJsonData<Ad>(sidx, sord, page, rows, adData);
        }
        #endregion 
    }
}