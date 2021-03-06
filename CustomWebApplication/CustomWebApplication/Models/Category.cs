﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomWebApplication.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public virtual IEnumerable<Album> Albums { get; set; }

        public static IEnumerable<Category> GetCategoriesList()
        {
            var categories = new List<Category>
            {
                new Category(){CategoryID=1, CategoryName="Rock",CategoryImage="rock.jpg"},
                new Category(){CategoryID=2, CategoryName="Metal", CategoryImage="metal.jpg"},
                new Category(){CategoryID=3,CategoryName="Rap", CategoryImage="rap.jpg"}
            };
            return categories;
        }

    }
}