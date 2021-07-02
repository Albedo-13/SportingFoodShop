using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportingFoodShop.Models
{
    public class ShoppingCart   //! Переименовать в Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Weight { get; set; } // граммы, таблетки, капсулы
        public decimal Cost { get; set; } // bel rubles
        public int Quantity { get; set; } // Кол-во одного товара в корзине
        public DateTime OrderTime { get; set; }
        public string ReadyOrderPrediction { get; set; }
        public bool State { get; set; }   // false-не выдано заказчику, true-получено заказчиком

        public string PersonalOrderId { get; set; } // Персональный ключ заказа, предьявляемый заказчиком в магазине

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Place")]
        public int PlaceId { get; set; }
        public Place Place { get; set; }

        // public ICollection<Product> Products { get; set; } СТАРОЕ
    }

    public class LocalBasketElement    // Полная копия ShoppingCart, но без Id
    {
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string Weight { get; set; } // граммы, таблетки, капсулы
        public decimal Cost { get; set; } // bel rubles
        public int Quantity { get; set; } // Кол-во одного товара в корзине
        public string ImagePath { get; set; }   // Путь к изображению

        public Place Place { get; set; }
    }

    public class LocalBasket
    {
        public static List<LocalBasketElement> Boughts = new List<LocalBasketElement>() { };

        public LocalBasket()
        {
            Boughts = new List<LocalBasketElement>() { };
        }
    }
}