using CardsApi.Abstractions.Mappers;
using CardsApi.Enums;
using CardsApi.Models;
using CardsApi.Requests;

namespace CardsApi.Mappers
{
    public class CreateCardRequestToCardMapper : BaseMapper<CreateCardRequest, Card>
    {
        public override Card Map(CreateCardRequest source)
        {
            if (source == null)
            {
                return null;
            }

            return new Card
            {
                Name = source.Name,
                Color = source.Color,
                Description = source.Description,
                Status = Status.ToDo,
                DateCreated = DateTime.Now
            };
        }
    }
}
