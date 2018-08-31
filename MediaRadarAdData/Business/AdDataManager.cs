using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MediaRadarAdData.AdDataService;
using MediaRadarAdData.Models;

namespace MediaRadarAdData.Business
{
    /// <summary>
    /// Provides the methods for the various Ad operations
    /// </summary>
    public class AdDataManager
    {
        #region Public Methods
        /// <summary>
        /// Provides all the ad data for the given date range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<Ad> GetAllAdData(DateTime startDate, DateTime endDate)
        {
            return AdDataProvider.GetAdDataForGivenRange(startDate, endDate).ToList();
        }

        /// <summary>
        /// Provides the Cover ads with more than half page coverage
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<Ad> GetCoverageData(DateTime startDate, DateTime endDate)
        {
            var adData = AdDataProvider.GetAdDataForGivenRange(startDate, endDate);
            return adData.Where(x => x.Position == Constants.POSITION_COVER && x.NumPages >= 0.5M).ToList();
        }

        /// <summary>
        /// Provides top five ads by page coverage amount, distinct by brand.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<Ad> GetTop5Ads(DateTime startDate, DateTime endDate)
        {
            var adData = AdDataProvider.GetAdDataForGivenRange(startDate, endDate);
            var top5AdData = adData.OrderByDescending(x => x.NumPages)
                            .GroupBy(x => x.Brand.BrandId)
                            .Take(5)
                            .Select(x => x.First())
                            .OrderByDescending(x => x.NumPages).ThenBy(x=>x.Brand.BrandName)                        
                            .ToList();
            return top5AdData;
        }

        /// <summary>
        /// Provides the top five brands by page coverage amount.
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<BrandCoverage> GetTop5Brands(DateTime startDate, DateTime endDate)
        {
            var adData = AdDataProvider.GetAdDataForGivenRange(startDate, endDate);
            var top5Brands = adData.GroupBy(x => new {x.Brand.BrandId, x.Brand.BrandName })
                            .Select(x => new BrandCoverage
                            {
                                Brand = new Brand { BrandId = x.Key.BrandId, BrandName = x.Key.BrandName},
                                TotalCoverage = x.Sum(y=>y.NumPages)
                            })
                            .OrderByDescending(x => x.TotalCoverage).ThenBy(x => x.Brand.BrandName)
                            .ToList();
            return top5Brands;
        }

        #endregion
    }
}