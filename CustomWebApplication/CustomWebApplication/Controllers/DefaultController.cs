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

        public JsonResult GetSearchingData(int categoryID, string searchBy, string searchValue)
        {
            var albumsWithCategory = (from album in Album.GetAlbumList()
                                      join category in Category.GetCategoriesList()
                                      on album.CategoryID equals category.CategoryID
                                      where (categoryID == album.CategoryID)
                                      select album).ToList();
            List<Album> newAlbumList;

            if (searchBy == "albumID")
            {
                 int Id = Convert.ToInt32(searchValue);
                 newAlbumList = albumsWithCategory.Where(x => x.AlbumID == Id || searchValue == null).ToList();


                return Json(newAlbumList, JsonRequestBehavior.AllowGet);
            }
            else if (searchBy == "AlbumName")
            {
                newAlbumList = albumsWithCategory.Where(x => x.AlbumName.StartsWith(searchValue, StringComparison.InvariantCultureIgnoreCase) || searchValue == null).ToList();
                return Json(newAlbumList, JsonRequestBehavior.AllowGet);
            }
            else if (searchBy == "BandName")
            {
                newAlbumList = albumsWithCategory.Where(x => x.BandName.StartsWith(searchValue, StringComparison.InvariantCultureIgnoreCase) || searchValue == null).ToList();
                return Json(newAlbumList, JsonRequestBehavior.AllowGet);
            }
            else if (searchBy == "Price")
            {
            
                int Pr = Convert.ToInt32(searchValue);
                newAlbumList = albumsWithCategory.Where(x => x.Price == Pr || searchValue == null).ToList();
                if (!int.TryParse(searchValue, out Pr))
                {
                    throw new FormatException();
                }
                return Json(newAlbumList, JsonRequestBehavior.AllowGet);
            }
            else {
                return Json(albumsWithCategory, JsonRequestBehavior.AllowGet);
            }       
        }

    }
}