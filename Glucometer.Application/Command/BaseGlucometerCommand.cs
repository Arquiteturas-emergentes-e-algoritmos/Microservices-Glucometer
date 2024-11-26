using Glucometer.Application.Command.Abstract;

namespace Glucometer.Application.Command;

public abstract class BaseGlucometerCommand : ICommandRequest
{
    public Guid UserId { get; set; } = Guid.Empty;

    public virtual bool Validate()
    {
        if (UserId == Guid.Empty) return false;
        return true;
    }
}
