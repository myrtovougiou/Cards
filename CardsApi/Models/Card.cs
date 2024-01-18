using CardsApi.Abstractions.Models;
using CardsApi.Enums;

namespace CardsApi.Models
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public Status Status { get; set; }
    }
}
