using CustomWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomWebApplication.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            BigViewModel bvm = new BigViewModel
            {
                Albums = Album.GetAlbumList(),
                Categories = Category.GetCategoriesList(),
                Songs = Song.GetSongList()
            };
            //albumList = bvm.Albums;
            return View(bvm);
        }

        public JsonResult LocationsToJson()
        {
            var locations = Location.GetLocationList();

            return Json(locations, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetMarkerInfo(int locationID)
        {
            Location location;
            location = Location.GetLocationList().Where(x => x.LocationID == locationID).FirstOrDefault();

            return Json(location, JsonRequestBehavior.AllowGet);
        }
    }
}