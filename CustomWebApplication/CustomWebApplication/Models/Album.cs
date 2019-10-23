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
        public decimal Price { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
        public virtual Category Category { get; set; }
    }
}