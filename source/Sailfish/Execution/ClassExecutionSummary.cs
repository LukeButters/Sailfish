﻿using System;
using System.Collections.Generic;
using System.Linq;
using Sailfish.Statistics;

namespace Sailfish.Execution;

public interface IClassExecutionSummary
{
    Type TestClass { get; set; }
    IExecutionSettings ExecutionSettings { get; }
    IEnumerable<ICompiledTestCaseResult> CompiledTestCaseResults { get; set; }

    IEnumerable<ICompiledTestCaseResult> GetSuccessfulTestCases();
    IEnumerable<ICompiledTestCaseResult> GetFailedTestCases();
    IClassExecutionSummary FilterForSuccessfulTestCases();
    IClassExecutionSummary FilterForFailureTestCases();
}

internal class ClassExecutionSummary : IClassExecutionSummary
{
    public ClassExecutionSummary(
        Type type,
        IExecutionSettings executionSettings,
        IEnumerable<ICompiledTestCaseResult> compiledResults)
    {
        TestClass = type;
        CompiledTestCaseResults = compiledResults;
        ExecutionSettings = executionSettings;
    }


    public Type TestClass { get; set; }
    public IExecutionSettings ExecutionSettings { get; }
    public IEnumerable<ICompiledTestCaseResult> CompiledTestCaseResults { get; set; }

    public IEnumerable<ICompiledTestCaseResult> GetSuccessfulTestCases()
    {
        return CompiledTestCaseResults.Where(x => x.PerformanceRunResult is not null);
    }

    public IEnumerable<ICompiledTestCaseResult> GetFailedTestCases()
    {
        return CompiledTestCaseResults.Where(x => x.PerformanceRunResult is null);
    }

    public IClassExecutionSummary FilterForSuccessfulTestCases()
    {
        return new ClassExecutionSummary(TestClass, ExecutionSettings, GetSuccessfulTestCases());
    }

    public IClassExecutionSummary FilterForFailureTestCases()
    {
        return new ClassExecutionSummary(TestClass, ExecutionSettings, GetFailedTestCases());
    }
}