using System.Diagnostics.CodeAnalysis;

namespace CarManager.Domain.ValueObjects;

public abstract record SingleValueObject<TValue>
{
    [AllowNull]
    public TValue Value { get; protected init; }

    public static implicit operator TValue(SingleValueObject<TValue>? vo) => vo is null ? default! : vo.Value;

    public sealed override string ToString()
    {
        return Value + "";
    }
}