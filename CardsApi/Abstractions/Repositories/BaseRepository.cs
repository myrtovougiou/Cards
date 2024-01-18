using CardsApi.Abstractions.Models;
using Microsoft.EntityFrameworkCore;

namespace CardsApi.Abstractions.Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected CardsDbContext DbContext { get; private set; }
        protected DbSet<TEntity> Entities { get; private set; }

        protected BaseRepository(CardsDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            Entities = dbContext.Set<TEntity>();
        }
    }
}
