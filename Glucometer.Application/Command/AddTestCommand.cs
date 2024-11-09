namespace Glucometer.Application.Command;

public class AddTestCommand : BaseGlucometerCommand
{
    public ushort Value { get; set; } = 0;
    public DateTime Time { get; set; } = DateTime.MinValue;

    public override bool Validate()
    {
        if (Time == DateTime.MinValue || Value == 0 || !base.Validate()) return false;
        return true;
    }
}