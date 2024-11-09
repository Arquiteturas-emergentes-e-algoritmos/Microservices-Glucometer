using Glucometer.Application.Command;
using Glucometer.Application.Command.Abstract;
using Glucometer.Application.Repository;
using Glucometer.Application.Services.Abstract;
using Glucometer.Domain.Entities;

namespace Glucometer.Application.Services;

public class GlucometerService(IGlucometerRepository glucometerRepository) : BaseService
{
    private readonly IGlucometerRepository _glucometerRepository = glucometerRepository;
    public CommandResponse Handle(AddTestCommand command)
    {
        GlucoseTest test = new(command.Value, command.Time);
        var glucometer = _glucometerRepository.GetById(command.GlucometerId);
        glucometer.AddTest(test);
        _glucometerRepository.Update(glucometer);
        return new CommandResponse(null, 200);
    }

    public CommandResponse Handle(GetGlucometerCommand command)
    {
        return new CommandResponse(_glucometerRepository.GetById(command.GlucometerId), 200);
    }

    public CommandResponse Handle(UpdateTestCommand command)
    {
        var glucometer = _glucometerRepository.GetById(command.GlucometerId);
        glucometer.UpdateTest(command.GlucoseTest);
        _glucometerRepository.Update(glucometer);
        return new CommandResponse(null, 200);
    }
    public CommandResponse Handle(DeleteTestCommand command)
    {
        var glucometer = _glucometerRepository.GetById(command.GlucometerId);
        glucometer.DeleteTest(command.TestId);
        _glucometerRepository.Update(glucometer);
        return new CommandResponse(null, 200);
    }
}
