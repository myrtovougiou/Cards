namespace CardsApi.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        Task SaveAsync(CancellationToken token = default);
    }
}
