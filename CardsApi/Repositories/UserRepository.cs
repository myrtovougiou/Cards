using CardsApi.Abstractions.Mappers;
using CardsApi.Abstractions.Repositories;
using CardsApi.Dtos;
using CardsApi.Models;
using CardsApi.Requests;
using Microsoft.EntityFrameworkCore;

namespace CardsApi.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly IMapper<User, UserDto> _userDtoMapper;

        public UserRepository(
            IMapper<User, UserDto> userDtoMapper,
            CardsDbContext dbContext) 
            : base(dbContext)
        { 
            _userDtoMapper = userDtoMapper ?? throw new ArgumentNullException(nameof(userDtoMapper));
        }

        public async Task<UserDto> GetUserAsync(
            UserRequest request,
            CancellationToken token = default)
        {
            var user = await Entities
                .Where(x => x.Email == request.Email && x.Password == request.Password)
                .FirstOrDefaultAsync(token);

            return _userDtoMapper.Map(user);
        }

        public async Task<string> AuthenticateUserAsync(
            UserRequest request,
            CancellationToken token = default)
        {
            var user = await GetUserAsync(request, token);

            if (user == null)
            {
                return string.Empty;
            }

            return string.Concat(user.Email, ":", user.Password);
        }
    }
}
