using SeraySis.BLL;
using SeraySis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace SeraySis.WebApp.Models
{
    public class CacheHelper
    {
        //public static List<Category> GetCategoriesFromCache()
        //{
        //    var result = WebCache.Get("category-cache");

        //    if (result == null)
        //    {

        //        CategoryManager categoryManager = new CategoryManager();
        //        result = categoryManager.List();
        //        WebCache.Set("category-cache", result, 20, true);
        //    }
        //    return result;
        //}

        //public static void RemoveCategoriesFrom(string key)
        //{
        //    Remove("category-cache");
        //}

        public static void Remove(string key)
        {
            WebCache.Remove(key);
        }
    }
}