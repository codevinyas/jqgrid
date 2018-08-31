using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MediaRadarAdData.AdDataService;

namespace MediaRadarAdData.Business
{
    /// <summary>
    /// Provides the ad data by invoking the WCF service
    /// </summary>
    public class AdDataProvider
    {
        #region Public Methods
        /// <summary>
        /// Provides the ad data by obtaining the data for a given date range from the WCF service.
        /// It also caches the data in the session for future usage
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<Ad> GetAdDataForGivenRange(DateTime startDate, DateTime endDate)
        {
            // Check if the data is already in the session for the given date range. If so return the session information
            var sessionStartDate = HttpContext.Current.Session[Constants.SESSION_START_DATE];
            var sessionEndDate = HttpContext.Current.Session[Constants.SESSION_END_DATE];
            var sessionData = HttpContext.Current.Session[Constants.SESSION_AD_DATA];
            if (sessionData != null && sessionStartDate != null && Convert.ToDateTime(sessionStartDate) == startDate
                && endDate != null && Convert.ToDateTime(sessionEndDate) == endDate) {
                return HttpContext.Current.Session[Constants.SESSION_AD_DATA] as List<Ad>;
            }

            // Get the add data and store it in the session
            var adData = GetAdData(startDate, endDate);
            HttpContext.Current.Session[Constants.SESSION_AD_DATA] = adData;
            HttpContext.Current.Session[Constants.SESSION_START_DATE] = startDate;
            HttpContext.Current.Session[Constants.SESSION_END_DATE] = endDate;
            return adData;
        }
        #endregion

        #region Private Methods
        private static List<Ad> GetAdData(DateTime startDate, DateTime endDate)
        {
            var adDataService = new AdDataServiceClient();
            return adDataService.GetAdDataByDateRange(startDate, endDate);
        }
        #endregion
    }
}