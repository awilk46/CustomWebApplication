using CustomWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace CustomWebApplication.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult AlbumListByCategory(int categoryID, string sortBy)
        {
           //string sortBy="";
            ViewBag.SortAlbumNameParameter = string.IsNullOrEmpty(sortBy) ? "AlbumName desc" : "";
            ViewBag.SortBandNameParameter = sortBy == "BandName" ? "BandName desc" : "BandName";

            var albumsWithCategory = (from album in Album.GetAlbumList()
                                 join category in Category.GetCategoriesList()
                                 on album.CategoryID equals category.CategoryID
                                 where (categoryID == album.CategoryID)
                                 select album).ToList().AsQueryable();

            switch (sortBy)
            {
                case "AlbumName desc":
                    albumsWithCategory = albumsWithCategory.OrderByDescending(x=>x.AlbumName);
                    break;
                case "BandName desc":
                    albumsWithCategory = albumsWithCategory.OrderByDescending(x => x.BandName);
                    break;
                case "BandName":
                    albumsWithCategory = albumsWithCategory.OrderBy(x => x.BandName);
                    break;
                default:
                    albumsWithCategory = albumsWithCategory.OrderBy(x => x.AlbumName);
                    break;
            }

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

        public JsonResult GetSearchingData(int categoryID, string searchBy, string searchValue)
        {
            BigViewModel bvm;

            if (searchBy == "AlbumName")
            {
                var albumsWithCategory = (from album in Album.GetAlbumList()
                                          join category in Category.GetCategoriesList()
                                          on album.CategoryID equals category.CategoryID
                                          where (categoryID == album.CategoryID)
                                          select album).Where(x => x.AlbumName.
                                          StartsWith(searchValue, StringComparison.InvariantCultureIgnoreCase) 
                                          || searchValue == "")
                                          .ToList();
                bvm = new BigViewModel()
                {
                    Albums = albumsWithCategory
                };
                return Json(albumsWithCategory, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var albumsWithCategory = (from album in Album.GetAlbumList()
                                          join category in Category.GetCategoriesList()
                                          on album.CategoryID equals category.CategoryID
                                          where (categoryID == album.CategoryID)
                                          select album).Where(x => x.BandName.
                                          StartsWith(searchValue, StringComparison.InvariantCultureIgnoreCase)
                                          || searchValue == "")
                                          .ToList();
                bvm = new BigViewModel()
                {
                    Albums = albumsWithCategory
                };
                return Json(albumsWithCategory, JsonRequestBehavior.AllowGet);
            }
    
        }

    }
}