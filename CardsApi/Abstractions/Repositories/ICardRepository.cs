using CardsApi.Models;
using CardsApi.Requests;

namespace CardsApi.Abstractions.Repositories
{
    public interface ICardRepository
    {
        Task<Card> GetByIdAsync(Guid id, CancellationToken token = default);
        Task<IEnumerable<Card>> GetAsync(CardRequest request, CancellationToken token = default);
        Task<Card> CreateAsync(Card card, CancellationToken token = default);
        Task<Card> DeleteAsync(Guid id, CancellationToken token = default);
        Card Update(Card entity, Card updatedEntity);
    }
}
