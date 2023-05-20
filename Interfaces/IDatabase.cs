namespace Interfaces
{
    public interface IDatabase<T> where T : IDbEntity
    {
        void AddOrUpdate(T element);

        bool Contains(Func<T, bool> predicate);

        bool Delete(Guid key);

        IEnumerable<T> GetValues();
    }
}