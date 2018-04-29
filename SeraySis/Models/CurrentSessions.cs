using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeraySis.Entities;

namespace SeraySis.WebApp.Models
{
    //Her defasinda kullaniciyi kontrol etmemek icin
    //Session islemlerini daha kolay hale getirdik

    public class CurrentSession
    {
        //newlemeden cagirabilmek icin static yaptik
        public static Users CurrentUser
        {
            get
            {

                return Get<Users>("seraysis-online");

                //Yukaridaki kodu yazarak assadaki kodlari yazmama gerek kalmadi assadagi get metodunu cagirdik 

                /*
                if (HttpContext.Current.Session["doktrini-online"] != null)
                {
                    return HttpContext.Current.Session["doktrini-online"] as Users;  
                }

                return null;
                */

            }
        }

        //Sessionda obje tutmak icin
        public static void Set<T>(string key, T obj)
        {
            HttpContext.Current.Session[key] = obj;
        }

        public static T Get<T>(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                return (T)HttpContext.Current.Session[key];
            }


            return default(T);
        }

        public static void Remove(string key)
        {
            if (HttpContext.Current.Session[key] != null)
            {
                HttpContext.Current.Session.Remove(key);
            }
        }

        public static void Clear()
        {
            HttpContext.Current.Session.Clear();
        }

    }
}