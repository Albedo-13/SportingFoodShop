using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SportingFoodShop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal TotalSpentMoney { get; set; }

        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public ICollection<ShoppingCart> Orders { get; set; }
    }

    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }

    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [StringLength(16, MinimumLength = 3, ErrorMessage = "Никнейм должен быть размером от 3 до 16 символов")]
        public string Nickname { get; set; }
        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Введенная почта не соотвествует формату [имя]@[почта].[домен]")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(?!^[0-9]*$)(?!^[a-z]*$)^([a-z0-9!@#$%^&*()_+=\[{\]};:<>|./?,-]{8,15})$", ErrorMessage = "Минимум 1 буква, без пробелов, 8-15 символов")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}