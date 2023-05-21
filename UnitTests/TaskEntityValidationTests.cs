using DTOs;
using MockDatabaseLayer;
using Validation;

namespace UnitTests
{
    [TestClass]
    public class TaskEntityValidationTests
    {
        [TestMethod]
        public void TestNameValidationExpectFail()
        {
            var db = new MockDatabase<TaskEntity>();
            var t1 = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test",
                Priority = 1,
                Status = Status.InProgress
            };
            db.AddOrUpdate(t1);
            var t2 = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test2",
                Priority = 1,
                Status = Status.InProgress
            };
            db.AddOrUpdate(t2);

            var valid = new TaskEntityValidation();
            var t3 = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test",
                Priority = 1,
                Status = Status.InProgress
            };
            Assert.IsFalse(valid.IsValid(db, t3).isValid);
        }

        [TestMethod]
        public void TestNameEmptyExpectFail()
        {
            var db = new MockDatabase<TaskEntity>();

            var valid = new TaskEntityValidation();
            var t = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = " ",
                Priority = 1,
                Status = Status.InProgress
            };
            Assert.IsFalse(valid.IsValid(db, t).isValid);
        }

        [TestMethod]
        public void TestNameValidationExpectSuccess()
        {
            var db = new MockDatabase<TaskEntity>();
            var t1 = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test",
                Priority = 1,
                Status = Status.InProgress
            };
            db.AddOrUpdate(t1);
            var t2 = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test2",
                Priority = 1,
                Status = Status.InProgress
            };
            db.AddOrUpdate(t2);

            var valid = new TaskEntityValidation();
            var t3 = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test3",
                Priority = 1,
                Status = Status.InProgress
            };
            Assert.IsTrue(valid.IsValid(db, t3).isValid);
        }
    }
}