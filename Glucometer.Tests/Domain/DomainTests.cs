using Glucometer.Domain.Entities;

namespace Glucometer.Tests.Domain;

[TestClass]
public class DomainTests
{
    [DataTestMethod]
    [DataRow("2023-01-01T10:00:00", "2023-01-01T09:00:00")]
    public void AddTest_ShouldAddAndSortTestsByTime(string time1, string time2)
    {
        var glucometer = new Glucometer.Domain.Entities.Glucometer();
        var test1 = new GlucoseTest { Id = Guid.NewGuid(), Time = DateTime.Parse(time1) };
        var test2 = new GlucoseTest { Id = Guid.NewGuid(), Time = DateTime.Parse(time2) };

        glucometer.AddTest(test1);
        glucometer.AddTest(test2);

        Assert.AreEqual(2, glucometer.GlucoseTests.Count);
    }

    [DataTestMethod]
    [DataRow("2023-01-01T10:00:00")]
    [DataRow("2023-01-01T08:00:00")]
    public void DeleteTest_ShouldRemoveTestById(string time)
    {
        var glucometer = new Glucometer.Domain.Entities.Glucometer();
        var testId = Guid.NewGuid();
        var test = new GlucoseTest { Id = testId, Time = DateTime.Parse(time) };
        glucometer.AddTest(test);

        glucometer.DeleteTest(testId);

        Assert.AreEqual(0, glucometer.GlucoseTests.Count);
    }

    [DataTestMethod]
    [DataRow("2023-01-01T10:00:00", "2023-01-01T11:00:00")]
    [DataRow("2023-01-01T08:00:00", "2023-01-01T09:00:00")]
    public void UpdateTest_ShouldUpdateExistingTestAndSortByTime(string oldTime, string newTime)
    {
        var glucometer = new Glucometer.Domain.Entities.Glucometer();
        var testId = Guid.NewGuid();
        var oldTest = new GlucoseTest { Id = testId, Time = DateTime.Parse(oldTime) };
        glucometer.AddTest(oldTest);

        var updatedTest = new GlucoseTest { Id = testId, Time = DateTime.Parse(newTime) };
        glucometer.UpdateTest(updatedTest);

        Assert.AreEqual(1, glucometer.GlucoseTests.Count);
        Assert.AreEqual(updatedTest.Time, glucometer.GlucoseTests[0].Time);
    }
}
