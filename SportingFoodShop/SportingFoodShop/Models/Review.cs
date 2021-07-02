using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingFoodShop.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [Range(1, 5, ErrorMessage = "Неверное число звезд")]
        public int Stars { get; set; }  // 1-5
        public DateTime ReviewDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Pluses { get; set; }
        public string Minuses { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}