using System;

namespace Sailfish.Attributes;

/// <summary>
/// Specifies that the attributed method is responsible for Sailfish iteration setup.
/// </summary>
/// <remarks>
/// This attribute should be placed on a single method. Multiple attributes per class are allowed.
/// </remarks>
/// <seealso href="https://paulgradie.com/Sailfish/docs/2/sailfish-lifecycle-method-attributes">Sailfish Lifecycle Method Attributes</seealso>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public sealed class SailfishIterationSetupAttribute : Attribute
{
    public SailfishIterationSetupAttribute(params string[] methodNames)
    {
        MethodNames = methodNames;
    }

    /// <summary>
    /// Array of method names that the SailfishIterationSetup method should be executed before
    /// </summary>
    public string[] MethodNames { get; }
}
