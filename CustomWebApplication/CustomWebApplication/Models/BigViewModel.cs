using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomWebApplication.Models
{
    public class BigViewModel
    {
        public IEnumerable<Album> Albums { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Song> Songs { get; set; }
    }
}