namespace Glucometer.Tests.Application;

using Glucometer.Application.Command;
using Glucometer.Application.Repository;
using Glucometer.Application.Services;
using Glucometer.Domain.Entities;
using Moq;

[TestClass]
public class GlucometerServiceTests
{
    private Mock<IGlucometerRepository> _mockRepository = null!;
    private GlucometerService _glucometerService = null!;

    [TestInitialize]
    public void Setup()
    {
        _mockRepository = new Mock<IGlucometerRepository>();
        _glucometerService = new GlucometerService(_mockRepository.Object);
    }

    [TestMethod]
    public void Handle_AddTestCommand_ShouldAddTestAndReturnSuccess()
    {
        // Arrange
        var glucometerId = Guid.NewGuid();
        var command = new AddTestCommand { UserId = glucometerId, Value = 100, Time = DateTime.Now };
        var glucometer = new Glucometer
        {
            Id = glucometerId
        };
        _mockRepository.Setup(repo => repo.GetById(glucometerId)).Returns(glucometer);

        // Act
        var response = _glucometerService.Handle(command);

        // Assert
        Assert.AreEqual(200, response.Status);
        _mockRepository.Verify(repo => repo.Update(glucometer), Times.Once);
    }

    [TestMethod]
    public void Handle_GetGlucometerCommand_ShouldReturnGlucometer()
    {
        // Arrange
        var glucometerId = Guid.NewGuid();
        var command = new GetGlucometerCommand { UserId = glucometerId };
        var glucometer = new Glucometer
        {
            Id = glucometerId
        };
        _mockRepository.Setup(repo => repo.GetById(glucometerId)).Returns(glucometer);

        // Act
        var response = _glucometerService.Handle(command);

        // Assert
        Assert.AreEqual(200, response.Status);
        Assert.AreEqual(glucometer, response.Data);
    }

    [TestMethod]
    public void Handle_UpdateTestCommand_ShouldUpdateTestAndReturnSuccess()
    {
        // Arrange
        var glucometerId = Guid.NewGuid();
        var glucoseTest = new GlucoseTest(120, DateTime.Now);
        var command = new UpdateTestCommand { UserId = glucometerId, GlucoseTest = glucoseTest };
        var glucometer = new Glucometer
        {
            Id = glucometerId
        };
        _mockRepository.Setup(repo => repo.GetById(glucometerId)).Returns(glucometer);

        // Act
        var response = _glucometerService.Handle(command);

        // Assert
        Assert.AreEqual(200, response.Status);
        _mockRepository.Verify(repo => repo.Update(glucometer), Times.Once);
    }

    [TestMethod]
    public void Handle_DeleteTestCommand_ShouldDeleteTestAndReturnSuccess()
    {
        // Arrange
        var glucometerId = Guid.NewGuid();
        var testId = Guid.NewGuid();
        var command = new DeleteTestCommand { UserId = glucometerId, TestId = testId };
        var glucometer = new Glucometer
        {
            Id = glucometerId
        };
        glucometer.AddTest(new GlucoseTest(110, DateTime.Now) { Id = testId });
        _mockRepository.Setup(repo => repo.GetById(glucometerId)).Returns(glucometer);

        // Act
        var response = _glucometerService.Handle(command);

        // Assert
        Assert.AreEqual(200, response.Status);
        _mockRepository.Verify(repo => repo.Update(glucometer), Times.Once);
    }
}


