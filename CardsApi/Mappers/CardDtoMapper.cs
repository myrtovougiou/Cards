using CardsApi.Abstractions.Mappers;
using CardsApi.Dtos;
using CardsApi.Models;

namespace CardsApi.Mappers
{
    public class CardDtoMapper : BaseMapper<Card, CardDto>
    {
        public override CardDto Map(Card source)
        {
            if (source == null)
            {
                return null;
            }

            return new CardDto
            {
                Name = source.Name,
                Color = source.Color,
                Description = source.Description,
                Status = source.Status.ToString(),
                DateCreated = source.DateCreated.ToShortDateString()
            };
        }
    };
}
