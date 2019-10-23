using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomWebApplication.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public int AlbumID { get; set; }      
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }        
        public DateTime OrderDate { get; set; }       
        public Album Album { get; set; }

        public static IEnumerable<Order> GetOrdersList()
        {
            var orders = new List<Order>
            {
                new Order(){OrderID=1,AlbumID=1,Name="Jan",Surname="Kowalski",Address="Niewiadomska 7",City="Warszawa",Postcode="00-001",Phone="111222333",Email="jk@google.com",OrderDate= new DateTime(2018,11,12)},
                new Order(){OrderID=2,AlbumID=2,Name="Jakub",Surname="Nowak",Address="Wiadomska 8",City="Lublin",Postcode="02-001",Phone="111222333",Email="jn@google.com",OrderDate= new DateTime(2019,6,2)},
                new Order(){OrderID=3,AlbumID=3,Name="Sandra",Surname="Owoc",Address="Rzemieślnicza 13/7",City="Kraków",Postcode="00-001",Phone="111735333",Email="so@google.com",OrderDate= new DateTime(2008,1,17)},
                new Order(){OrderID=4,AlbumID=4,Name="Krystyna",Surname="Ptak",Address="Krakowska 12",City="Rzeszów",Postcode="30-211",Phone="901322333",Email="kp@google.com",OrderDate= new DateTime(2018,10,22)},
                new Order(){OrderID=5,AlbumID=5,Name="Andrzej",Surname="Wilk",Address="Rzeszowska 7",City="Gdańsk",Postcode="00-123",Phone="221220453",Email="aw@google.com",OrderDate= new DateTime(2010,9,4)},
                new Order(){OrderID=6,AlbumID=6,Name="Małgorzata",Surname="Mostowiak",Address="Cmentarna 5/10",City="Suwałki",Postcode="99-001",Phone="092359185",Email="mm@google.com",OrderDate= new DateTime(2017,7,30)},
            };
            return orders;
        }
    }
}