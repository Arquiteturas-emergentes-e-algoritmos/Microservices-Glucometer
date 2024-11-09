using Glucometer.Domain.Entities;

namespace Glucometer.Application.Command;
public class UpdateTestCommand : BaseGlucometerCommand
{
    public GlucoseTest GlucoseTest { get; set; } = new GlucoseTest();
    public override bool Validate()
    {
        if (GlucoseTest.Time == DateTime.MinValue || GlucoseTest.Value == 0 || !base.Validate()) return false;
        return true;
    }
}