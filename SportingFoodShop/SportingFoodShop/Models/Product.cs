using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingFoodShop.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public int Weight { get; set; } // in grams
        public decimal Cost { get; set; } // bel rubles

        public int TotalBoughtItems { get; set; } // кол-во покупок определенного товара

        [ForeignKey("Image")]
        public int ImageId { get; set; }
        public Image Image { get; set; }

        [ForeignKey("AggregateType")]
        public int TypeId { get; set; }
        public AggregateType AggregateType { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public Category Categories { get; set; }

        // Average Rating (0 to 5)
        // TotalComments

        // Discount
        // ienumerable<Review> Reviews
        // Content content
    }
}