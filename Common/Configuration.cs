using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Common
{
    public class Configuration
    {
        public static string GetConfiguration(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
