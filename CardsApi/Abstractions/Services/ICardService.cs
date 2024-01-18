using CardsApi.Dtos;
using CardsApi.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace CardsApi.Abstractions.Services
{
    public interface ICardService
    {
        Task<CardDto> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<IEnumerable<CardDto>> GetAsync(CardRequest request, CancellationToken token = default);
        Task<CardDto> CreateAsync(CardRequest request, CancellationToken token = default);
        Task<CardDto> UpdateAsync(Guid id, JsonPatchDocument<CardRequest> patchDocument, CancellationToken token = default);
        Task<CardDto> DeleteAsync(Guid id, CancellationToken token = default);
    }
}
