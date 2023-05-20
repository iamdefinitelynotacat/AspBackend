using DTOs;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace asp_crud_demo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IDatabase<TaskEntity> database;
        private readonly IEntityValidation<TaskEntity> validation;
        private readonly object lockObject = new object();

        public TaskController(IDatabase<TaskEntity> database, IEntityValidation<TaskEntity> validation)
        {
            this.database = database;
            this.validation = validation;
        }

        /// <summary>
        /// Gets all TaskEntities from DB.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<TaskEntity[]> Get()
        {
            return database.GetValues().ToArray();
        }

        /// <summary>
        /// Adds or updates TaskEntity to DB
        /// </summary>
        /// <param name="entity">The entity to add or update.</param>
        /// <returns>OK or BadRequest.</returns>
        [HttpPost]
        public ActionResult Post([FromBody] TaskEntity entity)
        {
            lock (lockObject)
            {
                var validationResult = validation.IsValid(database, entity);
                if (validationResult.isValid)
                {
                    database.AddOrUpdate(entity);
                    return Ok();
                }
                else
                {
                    return BadRequest(validationResult.errorMessage);
                }
            }
        }

        /// <summary>
        /// Deteles the entity by key.
        /// </summary>
        /// <param name="key">Key of en entity to be deleted.</param>
        /// <returns>OK or BadRequest.</returns>
        [HttpDelete]
        public ActionResult Delete(Guid key)
        {
            var deletionResult = database.Delete(key);
            return deletionResult ? Ok() : BadRequest($"No Task with key:{key} found");
        }
    }
}