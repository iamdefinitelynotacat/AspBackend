using DTOs;
using Interfaces;

namespace Validation
{
    public class TaskEntityValidation : IEntityValidation<TaskEntity>
    {
        public (bool isValid, string errorMessage) IsValid(IDatabase<TaskEntity> database, TaskEntity element)
        {
            if (database.Contains(x => x.Name == element.Name && x.Key != element.Key))
                return (false, $"Task with the name:{element.Name} already exists");
            return (true, string.Empty);
        }
    }
}