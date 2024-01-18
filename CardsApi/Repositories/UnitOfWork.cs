using CardsApi.Abstractions.Repositories;

namespace CardsApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CardsDbContext _context;

        public UnitOfWork(CardsDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SaveAsync(CancellationToken token = default)
        {
            await _context.SaveChangesAsync();
        }
    }
}
