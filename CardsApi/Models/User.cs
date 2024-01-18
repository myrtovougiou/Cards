﻿using CardsApi.Abstractions.Models;

namespace CardsApi.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
