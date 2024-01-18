using CardsApi.Abstractions.Mappers;
using CardsApi.Models;
using CardsApi.Requests;

namespace CardsApi.Mappers
{
    public class CardMapper : BaseMapper<CardRequest, Card>
    {
        public override Card Map(CardRequest source)
        {
            if (source == null)
            {
                return null;
            }

            return new Card
            {
                Id = source.Id,
                Name = source.Name,
                Color = source.Color,
                Description = source.Description,
                Status = source.Status.Value,
                DateCreated = source.DateCreated.Value
            };
        }
    }
}
