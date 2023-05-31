using Shimakaze.Model;

namespace Shimakaze.Events;

public interface IOperatorEventArgs : IIMEventArgs
{
    IUser Operator { get; }
    DateTime OperatTime { get; }
}