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

        public static IEnumerable<Song> GetSongList()
        {
            var songs = new List<Song>
            {
                new Song(){SongID=1,AlbumID=1,SongName="R u mine?"},
                new Song(){SongID=2,AlbumID=1,SongName="Do I wanna know?"},
                new Song(){SongID=3,AlbumID=2,SongName="Teddy Picker"},
                new Song(){SongID=4,AlbumID=2,SongName="Brianstorm"},
                new Song(){SongID=5,AlbumID=3,SongName="Evil Deeds"},
                new Song(){SongID=6,AlbumID=3,SongName="Never Enough"},
                new Song(){SongID=7,AlbumID=4,SongName="Tony Tone"},
                new Song(){SongID=8,AlbumID=4,SongName="Changes"},
                new Song(){SongID=9,AlbumID=5,SongName="King nothing"},
                new Song(){SongID=10,AlbumID=5,SongName="Cure"},
                new Song(){SongID=11,AlbumID=6,SongName="Drifter"},
                new Song(){SongID=12,AlbumID=6,SongName="Invasion"},
                new Song(){SongID=13,AlbumID=7,SongName="R u mine?"},
                new Song(){SongID=14,AlbumID=7,SongName="Do I wanna know?"},
                new Song(){SongID=15,AlbumID=8,SongName="Teddy Picker"},
                new Song(){SongID=16,AlbumID=8,SongName="Brianstorm"},
                new Song(){SongID=17,AlbumID=9,SongName="Evil Deeds"},
                new Song(){SongID=18,AlbumID=9,SongName="Never Enough"},
                new Song(){SongID=19,AlbumID=10,SongName="Tony Tone"},
                new Song(){SongID=20,AlbumID=10,SongName="Changes"},
                new Song(){SongID=21,AlbumID=11,SongName="King nothing"},
                new Song(){SongID=22,AlbumID=11,SongName="Cure"},
                new Song(){SongID=23,AlbumID=12,SongName="Drifter"},
                new Song(){SongID=24,AlbumID=12,SongName="Invasion"}
            };

            return songs;
        }
    }
}