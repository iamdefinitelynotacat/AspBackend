using Interfaces;

namespace MockDatabaseLayer
{
    public class MockDatabase<T> : IDatabase<T> where T : IDbEntity
    {
        private readonly Dictionary<Guid, T> valueDictionary = new();

        /// <inheritdoc/>
        public void AddOrUpdate(T entity)
        {
            if (valueDictionary.ContainsKey(entity.Key))
            {
                valueDictionary[entity.Key] = entity;
            }
            else
            {
                valueDictionary.Add(entity.Key, entity);
            }
        }

        /// <inheritdoc/>
        public bool Contains(Func<T, bool> predicate)
        {
            return valueDictionary.Values.Any(predicate);
        }

        /// <inheritdoc/>
        public bool Delete(Guid key)
        {
            return valueDictionary.Remove(key, out _);
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetValues()
        {
            return valueDictionary.Values;
        }
    }
}