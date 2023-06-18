using Shimakaze.Model;

namespace Shimakaze.Event;

public interface IOperatorEventArgs : IIMEventArgs
{
    IUser Operator { get; }
    DateTime OperatTime { get; }
}