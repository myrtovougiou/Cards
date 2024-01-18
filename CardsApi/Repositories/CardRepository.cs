using CardsApi.Abstractions.Repositories;
using CardsApi.Models;
using CardsApi.Requests;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace CardsApi.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(CardsDbContext dbContext) : base(dbContext)
        { }

        public async Task<Card> GetByIdAsync(
            Guid id,
            CancellationToken token = default)
        {
            return await Entities.FindAsync(id, token);
        }

        public async Task<IEnumerable<Card>> GetAsync(
            CardRequest request,
            CancellationToken token = default)
        {
            IQueryable<Card> cards = Entities;

            if (request == null)
            {
                return null;
            }

            if (!request.Name.IsNullOrEmpty())
            {
                cards = cards.Where(x => x.Name == request.Name);
            }

            if (!request.Color.IsNullOrEmpty())
            {
                cards = cards.Where(x => x.Color == request.Color);
            }

            if (request.Status.HasValue)
            {
                cards = cards.Where(x => x.Status == request.Status.Value);
            }

            if (request.DateCreated.HasValue)
            {
                cards = cards.Where(x => x.DateCreated == request.DateCreated.Value);
            }

            return await cards.ToListAsync(token);
        }

        public async Task<Card> CreateAsync(
            Card card,
            CancellationToken token = default)
        {
            var result = await DbContext.AddAsync(card, token);
            return result.Entity;
        }

        public Card Update(
            Card entity,
            Card updatedEntity)
        {
            DbContext.Entry(entity).CurrentValues.SetValues(updatedEntity);
            return entity;
        }

        public async Task<Card> DeleteAsync(
            Guid id, 
            CancellationToken token = default)
        {
            var entity = await Entities.FindAsync(id, token);

            if (entity == null)
            {
                return null;
            }

            var result = Entities.Remove(entity);

            return result.Entity;
        }
    }
}
