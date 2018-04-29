using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeraySis.Common.Helpers
{
    public class ConfigHelper
    {
        //Webconfigde app settingse yazdiklarimizi tip bagimsiz cekebilmek icin

        public static T Get<T>(string key)
        {
            return (T)Convert.ChangeType(ConfigurationManager.AppSettings[key], typeof(T));
        }
    }
}
