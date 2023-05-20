namespace Interfaces
{
    public interface IDatabase<T> where T : IDbEntity
    {
        /// <summary>
        /// Adds or updates the entity.
        /// </summary>
        /// <param name="entity">The entity to add or update</param>
        void AddOrUpdate(T entity);

        /// <summary>
        /// Checks the existence of entity.
        /// </summary>
        /// <param name="predicate">Predicate used in check.</param>
        /// <returns>At least one entity in database matches the predicate.</returns>
        bool Contains(Func<T, bool> predicate);

        /// <summary>
        /// Deteles the entity by key.
        /// </summary>
        /// <param name="key">Key of en entity to be deleted.</param>
        /// <returns>Entity found and deleted.</returns>
        bool Delete(Guid key);

        /// <summary>
        /// Gets all entitys stored in db.
        /// </summary>
        /// <returns>All entitys stored in db.</returns>
        IEnumerable<T> GetValues();
    }
}