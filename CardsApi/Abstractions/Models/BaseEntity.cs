﻿namespace CardsApi.Abstractions.Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
