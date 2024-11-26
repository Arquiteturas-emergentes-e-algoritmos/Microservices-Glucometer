using Glucometer.Application.Command;
using Glucometer.Domain.Entities;
namespace Glucometer.Tests.Application;

[TestClass]
public class GlucometerCommandTests
{
    [DataTestMethod]
    [DataRow(0, "0001-01-01", "00000000-0000-0000-0000-000000000000", false)]
    [DataRow(100, "0001-01-01", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", false)]
    [DataRow(0, "2024-10-22T12:00:00", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", false)]
    [DataRow(100, "2024-10-22T12:00:00", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", true)]
    public void AddTestCommand_Validate_ShouldReturnExpectedResult(int value, string time, string glucometerId, bool expected)
    {
        var command = new AddTestCommand
        {
            UserId = Guid.Parse(glucometerId),
            Value = (ushort)value,
            Time = DateTime.Parse(time)
        };

        var result = command.Validate();

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("00000000-0000-0000-0000-000000000000", false)]
    [DataRow("b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", true)]
    public void DeleteTestCommand_Validate_ShouldReturnExpectedResult(string testId, bool expected)
    {
        var command = new DeleteTestCommand
        {
            UserId = Guid.NewGuid(),
            TestId = Guid.Parse(testId)
        };

        var result = command.Validate();

        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(0, "0001-01-01", "00000000-0000-0000-0000-000000000000", false)]
    [DataRow(100, "0001-01-01", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", false)]
    [DataRow(0, "2024-10-22T12:00:00", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", false)]
    [DataRow(100, "2024-10-22T12:00:00", "b1d2b1e3-8466-45d3-9f36-3d8fddf563a6", true)]
    public void UpdateTestCommand_Validate_ShouldReturnExpectedResult(int value, string time, string glucometerId, bool expected)
    {
        var glucoseTest = new GlucoseTest { Value = (ushort)value, Time = DateTime.Parse(time) };
        var command = new UpdateTestCommand
        {
            UserId = Guid.Parse(glucometerId),
            GlucoseTest = glucoseTest
        };

        var result = command.Validate();

        Assert.AreEqual(expected, result);
    }
}


