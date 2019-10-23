using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomWebApplication.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public virtual IEnumerable<Album> Albums { get; set; }

        public static IEnumerable<Category> GetCategoriesList()
        {
            var categories = new List<Category>
            {
                new Category(){CategoryID=1, CategoryName="Rock"},
                new Category(){CategoryID=2, CategoryName="Metal"},
                new Category(){CategoryID=3,CategoryName="Rap"}
            };
            return categories;
        }

    }
}