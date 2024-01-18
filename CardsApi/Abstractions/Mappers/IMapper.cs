namespace CardsApi.Abstractions.Mappers
{
    public interface IMapper<TFrom, TTo>
    {
        TTo Map(TFrom from);
        IEnumerable<TTo> Map(IEnumerable<TFrom> from);
    }
}
