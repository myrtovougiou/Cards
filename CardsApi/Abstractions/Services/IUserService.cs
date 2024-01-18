using CardsApi.Dtos;
using CardsApi.Requests;

namespace CardsApi.Abstractions.Services
{
    public interface IUserService
    {
        Task<UserDto> GetAsync(UserRequest request, CancellationToken token = default);
        Task<string> AuthenticateAsync(UserRequest request, CancellationToken token = default);
    }
}
