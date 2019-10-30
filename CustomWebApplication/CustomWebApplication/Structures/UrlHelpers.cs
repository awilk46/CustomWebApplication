using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomWebApplication.Structures
{
    public static class UrlHelpers
    {
        public static string ImagePath(this UrlHelper helper, string imageName)
        {
            var imageFolder = AppConfig.ImageFolder;
            var path = Path.Combine(imageFolder, imageName);
            var mainPath = helper.Content(path);
            return mainPath;
        }
    }
}