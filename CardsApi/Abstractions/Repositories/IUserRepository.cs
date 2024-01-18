using CardsApi.Dtos;
using CardsApi.Requests;

namespace CardsApi.Abstractions.Repositories
{
    public interface IUserRepository
    {
        Task<UserDto> GetUserAsync(UserRequest request, CancellationToken token = default);
        Task<string> AuthenticateUserAsync(UserRequest request, CancellationToken token = default);
    }
}
