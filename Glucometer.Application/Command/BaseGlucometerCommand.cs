using Glucometer.Application.Command.Abstract;

namespace Glucometer.Application.Command;

public abstract class BaseGlucometerCommand : ICommandRequest
{
    public Guid GlucometerId { get; set; } = Guid.Empty;

    public virtual bool Validate()
    {
        if (GlucometerId == Guid.Empty) return false;
        return true;
    }
}
