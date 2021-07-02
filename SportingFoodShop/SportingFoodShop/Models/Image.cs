using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingFoodShop.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        public string ImagePath { get; set; }
        public string ImageType { get; set; }
        public string ImageName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}