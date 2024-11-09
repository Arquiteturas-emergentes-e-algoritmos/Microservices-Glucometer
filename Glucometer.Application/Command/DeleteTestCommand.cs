namespace Glucometer.Application.Command;

public class DeleteTestCommand : BaseGlucometerCommand
{
    public Guid TestId { get; set; } = Guid.Empty;
    public override bool Validate()
    {
        if (TestId == Guid.Empty || !base.Validate()) return false;
        return true;
    }
}
