namespace Interfaces
{
    public interface IDbEntity
    {
        /// <summary>
        /// Primary key
        /// </summary>
        public Guid Key { get; set; }
    }
}