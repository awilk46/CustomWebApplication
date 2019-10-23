using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomWebApplication.Models
{
    public class Song
    {
        public int SongID { get; set; }
        public int AlbumID { get; set; }
        public string SongName { get; set; }
        public virtual Album Album { get; set; }
    }
}