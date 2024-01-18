using CardsApi.Abstractions.Mappers;
using CardsApi.Dtos;
using CardsApi.Models;

namespace CardsApi.Mappers
{
    public class UserDtoMapper : BaseMapper<User, UserDto>
    {
        public override UserDto Map(User source)
        {
            if (source == null)
            {
                return null;
            }

            return new UserDto
            {
                Email = source.Email,
                Password = source.Password
            };
        }
    }
}
