namespace Interfaces
{
    public interface IEntityValidation<T> where T : IDbEntity
    {
        (bool isValid, string errorMessage) IsValid(IDatabase<T> database, T element);
    }
}