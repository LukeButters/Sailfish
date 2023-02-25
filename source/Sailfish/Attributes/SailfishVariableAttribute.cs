using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sailfish.Exceptions;

namespace Sailfish.Attributes;

/// <summary>
///     This is used to decorate a property that will be referenced within the test.
///     A unique execution set of the performance tests is executed for each value provided,
///     where an execution set is the total number of executions specified by the
///     Sailfish attribute
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class SailfishVariableAttribute<T> : Attribute
{
    public SailfishVariableAttribute([MinLength(1)] params T[] n)
    {
        if (n.Length == 0) throw new SailfishException($"No values were provided to the {nameof(SailfishVariableAttribute<T>)} attribute.");
        N.AddRange(n);
    }

    public List<T> N { get; } = new();

    public T[] GetVariables()
    {
        return N.ToArray();
    }
}

[AttributeUsage(AttributeTargets.Property)]
public sealed class SailfishVariableAttribute : SailfishVariableAttribute<int>
{
    public SailfishVariableAttribute([MinLength(1)] params int[] n) : base(n)
    {
    }
}