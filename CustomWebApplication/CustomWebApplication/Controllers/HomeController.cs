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
                Orders = Order.GetOrdersList(),
                Songs = Song.GetSongList()
            };
            //albumList = bvm.Albums;
            return View(bvm);
        }
    }
}