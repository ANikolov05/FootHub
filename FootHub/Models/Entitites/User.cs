﻿using System.ComponentModel.DataAnnotations;

namespace FootHub.Models.Entitites
{
    public class User
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}
