using DTOs;
using Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Validation;

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

        [HttpGet]
        public ActionResult<TaskEntity[]> Get()
        {
            return database.GetValues().ToArray();
        }

        [HttpPost]
        public ActionResult<bool> Post([FromBody] TaskEntity entity)
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

        [HttpDelete]
        public ActionResult<bool> Delete(Guid key)
        {
            var deletionResult = database.Delete(key);
            return deletionResult ? Ok() : BadRequest($"No Task with key:{key} found");
        }
    }
}