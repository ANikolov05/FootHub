﻿namespace FootHub.Models
{
    public class UpdateUserDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }
    }
}
