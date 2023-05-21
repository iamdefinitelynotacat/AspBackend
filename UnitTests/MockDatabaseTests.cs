using DTOs;
using MockDatabaseLayer;

namespace UnitTests
{
    [TestClass]
    public class MockDatabaseTests
    {
        [TestMethod]
        public void TestAddOrUpdateAdd()
        {
            var db = new MockDatabase<TaskEntity>();
            var t = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test",
                Priority = 1,
                Status = Status.InProgress
            };

            db.AddOrUpdate(t);

            var tresult = db.GetValues().Single();

            Assert.IsNotNull(tresult);
            Assert.AreEqual(t.Key, tresult.Key);
            Assert.AreEqual(t.Name, tresult.Name);
            Assert.AreEqual(t.Priority, tresult.Priority);
            Assert.AreEqual(t.Status, tresult.Status);
        }

        [TestMethod]
        public void TestAddOrUpdateUpdate()
        {
            var db = new MockDatabase<TaskEntity>();

            var t0 = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test",
                Priority = 1,
                Status = Status.InProgress
            };

            db.AddOrUpdate(t0);

            var t = new TaskEntity
            {
                Key = t0.Key,
                Name = "Test2",
                Priority = 2,
                Status = Status.Completed
            };

            db.AddOrUpdate(t);

            var tresult = db.GetValues().Single();

            Assert.IsNotNull(tresult);
            Assert.AreEqual(t.Key, tresult.Key);
            Assert.AreEqual(t.Name, tresult.Name);
            Assert.AreEqual(t.Priority, tresult.Priority);
            Assert.AreEqual(t.Status, tresult.Status);
        }

        [TestMethod]
        public void TestContains()
        {
            var db = new MockDatabase<TaskEntity>();

            var t = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test",
                Priority = 1,
                Status = Status.InProgress
            };

            db.AddOrUpdate(t);

            var res = db.Contains(x => x.Key == t.Key);
            Assert.IsTrue(res);

            var falseRes = db.Contains(x => x.Name == "Test2");
            Assert.IsFalse(falseRes);
        }

        [TestMethod]
        public void TestDelete()
        {
            var db = new MockDatabase<TaskEntity>();

            var t = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test",
                Priority = 1,
                Status = Status.InProgress
            };

            db.AddOrUpdate(t);

            db.Delete(t.Key);

            Assert.AreEqual(0, db.GetValues().Count());
        }

        [TestMethod]
        public void TestGetValues()
        {
            var db = new MockDatabase<TaskEntity>();

            var t = new TaskEntity
            {
                Key = Guid.NewGuid(),
                Name = "Test",
                Priority = 1,
                Status = Status.InProgress
            };

            db.AddOrUpdate(t);

            var tresult = db.GetValues().Single();
            Assert.IsNotNull(tresult);
            Assert.AreEqual(t.Key, tresult.Key);
            Assert.AreEqual(t.Name, tresult.Name);
            Assert.AreEqual(t.Priority, tresult.Priority);
            Assert.AreEqual(t.Status, tresult.Status);
        }
    }
}