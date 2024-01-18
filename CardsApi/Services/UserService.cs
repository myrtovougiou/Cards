using CardsApi.Abstractions.Repositories;
using CardsApi.Abstractions.Services;
using CardsApi.Dtos;
using CardsApi.Requests;

namespace CardsApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) 
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public async Task<UserDto> GetAsync(
            UserRequest request,
            CancellationToken token = default)
        {
            return await _userRepository.GetUserAsync(request, token);
        }

        public async Task<string> AuthenticateAsync(
            UserRequest request,
            CancellationToken token = default)
        {
            return await _userRepository.AuthenticateUserAsync(request, token);
        }
    }
}
