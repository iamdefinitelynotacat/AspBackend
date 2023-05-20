namespace Interfaces
{
    public interface IEntityValidation<T> where T : IDbEntity
    {
        /// <summary>
        /// Checks if entity is valid and can be saved to database.
        /// </summary>
        /// <param name="database">The database to check against.</param>
        /// <param name="element">The element to check.</param>
        /// <returns>isValid means that it can be saved, if not errorMessage contains the error</returns>
        (bool isValid, string errorMessage) IsValid(IDatabase<T> database, T element);
    }
}