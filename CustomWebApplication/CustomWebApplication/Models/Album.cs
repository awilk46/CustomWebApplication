using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomWebApplication.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public int CategoryID { get; set; }      
        public string AlbumName { get; set; }
        public string BandName { get; set; }
        public int Year { get; set; }
        public string AlbumCover { get; set; }
        public decimal Price { get; set; }
        public virtual IEnumerable<Song> Songs { get; set; }
        public virtual Category Category { get; set; }

        public static IEnumerable<Album> GetAlbumList()
        {
            var albums = new List<Album>
            {
                new Album(){AlbumID=1,CategoryID=1,AlbumName="AM",BandName="Arctic Monkeys",Year=2013, Price=30, AlbumCover=""},
                new Album(){AlbumID=2,CategoryID=1,AlbumName="Favourite Worst Nightmare",BandName="Arctic Monkeys",Year=2006, Price=32,AlbumCover=""},
                new Album(){AlbumID=3,CategoryID=2,AlbumName="Encore",BandName="Eminem",Year=2004, Price=19,AlbumCover=""},
                new Album(){AlbumID=4,CategoryID=2,AlbumName="Testing",BandName="Asap Rocky",Year=2018, Price=10,AlbumCover=""},
                new Album(){AlbumID=5,CategoryID=3,AlbumName="Load",BandName="Metallica",Year=1996, Price=40,AlbumCover=""},
                new Album(){AlbumID=6,CategoryID=3,AlbumName="Killers",BandName="Iron Maiden",Year=1981, Price=16,AlbumCover=""},
            };

            return albums;
        }
    }
}