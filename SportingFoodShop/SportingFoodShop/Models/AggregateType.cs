using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingFoodShop.Models
{
    public class AggregateType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Postfix { get; set; } // грамм, штук

        public ICollection<Product> Products { get; set; }
    }
}