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
        public JsonResult SongListByAlbum(int albumID)
        {
            var songs = (from song in Song.GetSongList()
                         join album in Album.GetAlbumList()
                         on song.AlbumID equals album.AlbumID
                         where (albumID == album.AlbumID)
                         select song).ToList();
     
            return Json(songs,JsonRequestBehavior.AllowGet);
        }
        public JsonResult SongListByAlbum2(int albumID)
        {
            var songs = (from song in Song.GetSongList()
                         join album in Album.GetAlbumList()
                         on song.AlbumID equals album.AlbumID
                         where (albumID == album.AlbumID)
                         select song).ToList();

            return Json(new { html = songs }, JsonRequestBehavior.AllowGet);
        }
    }
}