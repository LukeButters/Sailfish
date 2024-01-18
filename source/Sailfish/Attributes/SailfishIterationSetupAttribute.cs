using System;

namespace Sailfish.Attributes;

/// <summary>
///     Specifies that the attributed method is responsible for Sailfish iteration setup.
/// </summary>
/// <remarks>
///     This attribute should be placed on a single method. Multiple attributes per class are allowed.
/// </remarks>
/// <seealso href="https://paulgradie.com/Sailfish/docs/2/sailfish-lifecycle-method-attributes">
///     Sailfish Lifecycle Method
///     Attributes
/// </seealso>
/// <remarks>
///     Initializes a new instance of the <see cref="SailfishIterationSetupAttribute" /> class
///     with the specified method names.
/// </remarks>
/// <param name="methodNames">The names of the methods to be called during the setup phase.</param>
/// <remarks>This feature is EXPERIMENTAL</remarks>
[AttributeUsage(AttributeTargets.Method)]
public sealed class SailfishIterationSetupAttribute(params string[] methodNames) : Attribute, IInnerLifecycleAttribute
{
    /// <summary>
    ///     Array of method names that the SailfishIterationSetup method should be executed before
    /// </summary>
    public string[] MethodNames { get; } = methodNames.Length > 0 ? methodNames : [];
}