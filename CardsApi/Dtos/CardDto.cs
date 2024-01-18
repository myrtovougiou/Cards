using CardsApi.Enums;

namespace CardsApi.Dtos
{
    public class CardDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Status { get; set; }
        public string DateCreated { get; set; }
    }
}
