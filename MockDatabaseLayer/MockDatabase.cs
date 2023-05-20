using Interfaces;

namespace MockDatabaseLayer
{
    public class MockDatabase<T> : IDatabase<T> where T : IDbEntity
    {
        private readonly Dictionary<Guid, T> valueDictionary = new();

        public void AddOrUpdate(T element)
        {
            if (valueDictionary.ContainsKey(element.Key))
            {
                valueDictionary[element.Key] = element;
            }
            else
            {
                valueDictionary.Add(element.Key, element);
            }
        }

        public bool Contains(Func<T, bool> predicate)
        {
            return valueDictionary.Values.Any(predicate);
        }

        public bool Delete(Guid key)
        {
            return valueDictionary.Remove(key, out _);
        }

        public IEnumerable<T> GetValues()
        {
            return valueDictionary.Values;
        }
    }
}