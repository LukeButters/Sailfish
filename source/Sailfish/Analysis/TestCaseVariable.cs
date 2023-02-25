﻿using System.Text.Json.Serialization;

namespace Sailfish.Analysis;

public class TestCaseVariable
{
    [JsonConstructor]
#pragma warning disable CS8618
    public TestCaseVariable()
#pragma warning restore CS8618
    {
    }

    public TestCaseVariable(string name, object value)
    {
        Name = name;
        Value = value;
    }

    public string Name { get; set; } = null!;
    public object Value { get; set; }
}