using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IOperatorEventArgs
{
    IUser Operator { get; }
    DateTime OperatTime { get; }
}
