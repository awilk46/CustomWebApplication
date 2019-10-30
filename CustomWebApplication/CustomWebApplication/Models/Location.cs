using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomWebApplication.Models
{
    public class Location
    {
        public int LocationID { get; set; }
        public string AlbumName { get; set; }
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Long { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public virtual Album Album { get; set; }

        public static IEnumerable<Location> GetLocationList()
        {
            var locations = new List<Location>
            {
                new Location(){LocationID=1, AlbumName="Favourite Worst Nightmare", Name="Miejsce 1",Latitude="50.052310",Long="21.408451",Address="Strumskiego 12, 39-200 Dębica",ImagePath=""},
                new Location(){LocationID=2, AlbumName="Encore", Name="Miejsce 2",Latitude="50.054667",Long="21.422529", Address="Rzeszowska 77, 39-200 Dębica",ImagePath=""}
            };

            return locations;
        }

    }
}