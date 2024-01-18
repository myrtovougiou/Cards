using CardsApi.Abstractions.Mappers;
using CardsApi.Models;
using CardsApi.Requests;

namespace CardsApi.Mappers
{
    public class CardRequestMapper : BaseMapper<Card, CardRequest>
    {
        public override CardRequest Map(Card source)
        {
            if (source == null)
            {
                return null;
            }

            return new CardRequest
            {
                Id = source.Id,
                Name = source.Name,
                Color = source.Color,
                Description = source.Description,
                Status = source.Status,
                DateCreated = source.DateCreated
            };
        }
    }
}
