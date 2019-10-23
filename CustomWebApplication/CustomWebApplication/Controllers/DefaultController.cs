using CustomWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomWebApplication.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult AlbumListByCategory(int categoryID)
        {

            var albumsWithCategory = (from album in Album.GetAlbumList()
                                 join category in Category.GetCategoriesList()
                                 on album.CategoryID equals category.CategoryID
                                 where (categoryID == album.CategoryID)
                                 select album).ToList();

            BigViewModel bvm = new BigViewModel
            {
                Albums = albumsWithCategory,
                Categories = Category.GetCategoriesList(),
                Orders = Order.GetOrdersList(),
                Songs = Song.GetSongList()
            };

            return View(bvm);
        }
    }
}