using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportingFoodShop.Models
{
    public class Place
    {
        [Key]
        public int Id { get; set; }
        public string ShopName { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        [StringLength(2)]
        public string HouseAdditionalLetter { get; set; }
    }
}