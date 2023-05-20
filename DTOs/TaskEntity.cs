using Interfaces;

namespace DTOs
{
    public class TaskEntity : IDbEntity
    {
        /// <summary>
        /// Name of the task
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The priority of the task, specified as "number".
        /// </summary>
        public int Priority { get; set; }

        /// <inheritdoc/>
        public Guid Key { get; set; }

        /// <summary>
        /// The status of the task
        /// </summary>
        public Status Status { get; set; }
    }
}