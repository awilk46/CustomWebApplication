using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CustomWebApplication.Structures
{
    public class AppConfig
    {
        private static string _imageFolder = ConfigurationManager.AppSettings["ImageFolder"];

        public static string ImageFolder
        {
            get
            {
                return _imageFolder;
            }
        }
    }
}