using Interfaces;

namespace DTOs
{
    public class TaskEntity : IDbEntity
    {
        public string Name { get; set; }
        public int Priority { get; set; }
        
        /// <summary>
        /// Potetional
        /// </summary>
        public Guid Key { get; set; }


        public Status Status { get; set; }
    }
}