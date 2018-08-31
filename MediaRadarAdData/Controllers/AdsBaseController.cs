using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Dynamic;

namespace MediaRadarAdData.Controllers
{
    /// <summary>
    /// Base class for all ads controllers
    /// </summary>
    public abstract class AdsBaseController : Controller
    {
        #region Public Methods
        /// <summary>
        /// Returns the json data required by jqgrid including paging information
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sidx">Sort Index</param>
        /// <param name="sord">Sort Order</param>
        /// <param name="page">Page Number</param>
        /// <param name="rows">No of rows per page</param>
        /// <param name="adsData">Ads data</param>
        /// <returns></returns>
        public JsonResult GetJsonData<T>(string sidx, string sord, int page, int rows, List<T> adsData)
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            int totalRecords = adsData.Count();
            int totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            var resultAdData = adsData.OrderBy(sidx + " " + sord)
                          .Skip(pageSize * (page - 1))
                          .Take(pageSize).ToList();

            var jsonData = new
            {
                total = totalPages,
                page = page,
                records = totalRecords,
                rows = resultAdData
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Returns the basic json data required by jqgrid, excluding the paging information
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="adsData">Ads data</param>
        /// <returns></returns>
        public JsonResult GetBasicJsonData<T> (List<T> adsData)
        {
            var jsonData = new
            {
                rows = adsData
            };

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}