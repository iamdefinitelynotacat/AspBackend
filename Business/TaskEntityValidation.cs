using DTOs;
using Interfaces;

namespace Validation
{
    public class TaskEntityValidation : IEntityValidation<TaskEntity>
    {
        /// <inheritdoc/>
        public (bool isValid, string errorMessage) IsValid(IDatabase<TaskEntity> database, TaskEntity element)
        {
            if (string.IsNullOrWhiteSpace(element.Name))
                return (false, $"Task name cannot be empty");

            if (database.Contains(x => x.Name == element.Name && x.Key != element.Key))
                return (false, $"Task with the name:{element.Name} already exists");
            return (true, string.Empty);
        }
    }
}