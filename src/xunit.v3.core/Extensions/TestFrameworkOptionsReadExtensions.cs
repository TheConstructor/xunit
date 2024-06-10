using System;
using System.Globalization;
using Xunit.Internal;
using Xunit.v3;

namespace Xunit.Sdk;

/// <summary>
/// Extension methods for reading <see cref="_ITestFrameworkDiscoveryOptions"/> and <see cref="_ITestFrameworkExecutionOptions"/>.
/// </summary>
public static class TestFrameworkOptionsReadExtensions
{
	// ======================================
	//   Read methods for discovery options
	// ======================================

	/// <summary>
	/// Gets the culture to use for discovering tests. <c>null</c> uses the default OS culture;
	/// <see cref="string.Empty"/> uses the invariant culture; any other value passes the
	/// provided value to <see cref="CultureInfo(string)"/> and uses the resulting object
	/// with <see cref="CultureInfo.DefaultThreadCurrentCulture"/> and
	/// <see cref="CultureInfo.DefaultThreadCurrentUICulture"/>.
	/// </summary>
	public static string? Culture(this _ITestFrameworkDiscoveryOptions discoveryOptions)
	{
		Guard.ArgumentNotNull(discoveryOptions);

		return discoveryOptions.GetValue<string?>(TestOptionsNames.Discovery.Culture);
	}

	/// <summary>
	/// Gets a flag that determines whether diagnostic messages will be emitted.
	/// </summary>
	public static bool? DiagnosticMessages(this _ITestFrameworkDiscoveryOptions discoveryOptions)
	{
		Guard.ArgumentNotNull(discoveryOptions);

		return discoveryOptions.GetValue<bool?>(TestOptionsNames.Discovery.DiagnosticMessages);
	}

	/// <summary>
	/// Gets a flag that determines whether diagnostic messages will be emitted. If the flag is not present,
	/// returns the default value (<c>false</c>).
	/// </summary>
	public static bool DiagnosticMessagesOrDefault(this _ITestFrameworkDiscoveryOptions discoveryOptions) =>
		DiagnosticMessages(discoveryOptions) ?? false;

	/// <summary>
	/// Gets a flag that determines whether discovered test cases should include source information.
	/// Note that not all runners have access to source information, so this flag does not guarantee
	/// that source information will be provided.
	/// </summary>
	public static bool? IncludeSourceInformation(this _ITestFrameworkDiscoveryOptions discoveryOptions)
	{
		Guard.ArgumentNotNull(discoveryOptions);

		return discoveryOptions.GetValue<bool?>(TestOptionsNames.Discovery.IncludeSourceInformation);
	}

	/// <summary>
	/// Gets a flag that determines whether discovered test cases should include source information.
	/// Note that not all runners have access to source information, so this flag does not guarantee
	/// that source information will be provided. If the flag is not present, returns the default
	/// value (<c>false</c>).
	/// </summary>
	public static bool IncludeSourceInformationOrDefault(this _ITestFrameworkDiscoveryOptions discoveryOptions) =>
		IncludeSourceInformation(discoveryOptions) ?? false;

	/// <summary>
	/// Gets a flag that determines the default display name format for test methods.
	/// </summary>
	public static TestMethodDisplay? MethodDisplay(this _ITestFrameworkDiscoveryOptions discoveryOptions)
	{
		Guard.ArgumentNotNull(discoveryOptions);

		var methodDisplayString = discoveryOptions.GetValue<string>(TestOptionsNames.Discovery.MethodDisplay);
		return methodDisplayString is not null ? (TestMethodDisplay?)Enum.Parse(typeof(TestMethodDisplay), methodDisplayString) : null;
	}

	/// <summary>
	/// Gets a flag that determines the default display name format for test methods. If the flag is not present,
	/// returns the default value (<see cref="TestMethodDisplay.ClassAndMethod"/>).
	/// </summary>
	public static TestMethodDisplay MethodDisplayOrDefault(this _ITestFrameworkDiscoveryOptions discoveryOptions) =>
		MethodDisplay(discoveryOptions) ?? TestMethodDisplay.ClassAndMethod;

	/// <summary>
	/// Gets a flag that determines the default display options to format test methods.
	/// </summary>
	public static TestMethodDisplayOptions? MethodDisplayOptions(this _ITestFrameworkDiscoveryOptions discoveryOptions)
	{
		Guard.ArgumentNotNull(discoveryOptions);

		var methodDisplayOptionsString = discoveryOptions.GetValue<string>(TestOptionsNames.Discovery.MethodDisplayOptions);
		return methodDisplayOptionsString is not null ? (TestMethodDisplayOptions?)Enum.Parse(typeof(TestMethodDisplayOptions), methodDisplayOptionsString) : null;
	}

	/// <summary>
	/// Gets the options that determine the default display formatting options for test methods. If no options are not present,
	/// returns the default value (<see cref="TestMethodDisplayOptions.None"/>).
	/// </summary>
	public static TestMethodDisplayOptions MethodDisplayOptionsOrDefault(this _ITestFrameworkDiscoveryOptions discoveryOptions) =>
		MethodDisplayOptions(discoveryOptions) ?? TestMethodDisplayOptions.None;

	/// <summary>
	/// Gets a flag that determines whether theories are pre-enumerated. If they enabled, then the
	/// discovery system will return a test case for each row of test data; they are disabled, then the
	/// discovery system will return a single test case for the theory.
	/// </summary>
	public static bool? PreEnumerateTheories(this _ITestFrameworkDiscoveryOptions discoveryOptions)
	{
		Guard.ArgumentNotNull(discoveryOptions);

		return discoveryOptions.GetValue<bool?>(TestOptionsNames.Discovery.PreEnumerateTheories);
	}

	/// <summary>
	/// Gets a flag that determines whether theories are pre-enumerated. If enabled, then the
	/// discovery system will return a test case for each row of test data; if disabled, then the
	/// discovery system will return a single test case for the theory. If the flag is not present,
	/// returns the default value (<c>false</c>).
	/// </summary>
	public static bool PreEnumerateTheoriesOrDefault(this _ITestFrameworkDiscoveryOptions discoveryOptions) =>
		PreEnumerateTheories(discoveryOptions) ?? false;

	/// <summary>
	/// Gets a flag that determines whether xUnit.net should report test results synchronously.
	/// </summary>
	public static bool? SynchronousMessageReporting(this _ITestFrameworkDiscoveryOptions discoveryOptions)
	{
		Guard.ArgumentNotNull(discoveryOptions);

		return discoveryOptions.GetValue<bool?>(TestOptionsNames.Execution.SynchronousMessageReporting);
	}

	/// <summary>
	/// Gets a flag that determines whether xUnit.net should report test results synchronously.
	/// If the flag is not set, returns the default value (<c>false</c>).
	/// </summary>
	public static bool SynchronousMessageReportingOrDefault(this _ITestFrameworkDiscoveryOptions discoveryOptions) =>
		SynchronousMessageReporting(discoveryOptions) ?? false;

	// ======================================
	//   Read methods for execution options
	// ======================================

	/// <summary>
	/// Gets the culture to use for running tests. <c>null</c> uses the default OS culture;
	/// <see cref="string.Empty"/> uses the invariant culture; any other value passes the
	/// provided value to <see cref="CultureInfo(string)"/> and uses the resulting object
	/// with <see cref="CultureInfo.DefaultThreadCurrentCulture"/> and
	/// <see cref="CultureInfo.DefaultThreadCurrentUICulture"/>.
	/// </summary>
	public static string? Culture(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<string?>(TestOptionsNames.Execution.Culture);
	}

	/// <summary>
	/// Gets a flag that determines whether diagnostic messages will be emitted.
	/// </summary>
	public static bool? DiagnosticMessages(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<bool?>(TestOptionsNames.Execution.DiagnosticMessages);
	}

	/// <summary>
	/// Gets a flag that determines whether diagnostic messages will be emitted. If the flag is not
	/// present, returns the default value (<c>false</c>).
	/// </summary>
	public static bool DiagnosticMessagesOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		DiagnosticMessages(executionOptions) ?? false;

	/// <summary>
	/// Gets a flag to disable parallelization.
	/// </summary>
	public static bool? DisableParallelization(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<bool?>(TestOptionsNames.Execution.DisableParallelization);
	}

	/// <summary>
	/// Gets a flag to disable parallelization. If the flag is not present, returns the
	/// default value (<c>false</c>).
	/// </summary>
	public static bool DisableParallelizationOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		DisableParallelization(executionOptions) ?? false;

	/// <summary>
	/// Gets a flag that indicates how to handle explicit tests.
	/// </summary>
	public static ExplicitOption? ExplicitOption(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		var explicitText = executionOptions.GetValue<string?>(TestOptionsNames.Execution.ExplicitOption);
		if (Enum.TryParse<ExplicitOption>(explicitText, out var result))
			return result;

		return null;
	}

	/// <summary>
	/// Gets a flag that indicates how to handle explicit tests. If the flag is not present, returns the
	/// default value (<see cref="ExplicitOption.Off"/>).
	/// </summary>
	public static ExplicitOption ExplicitOptionOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		ExplicitOption(executionOptions) ?? Sdk.ExplicitOption.Off;

	/// <summary>
	/// Gets a flag to fail skipped tests.
	/// </summary>
	public static bool? FailSkips(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<bool?>(TestOptionsNames.Execution.FailSkips);
	}

	/// <summary>
	/// Gets a flag to fail skipped tests. If the flag is not present, returns the
	/// default value (<c>false</c>).
	/// </summary>
	public static bool FailSkipsOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		FailSkips(executionOptions) ?? false;

	/// <summary>
	/// Gets a flag to fail passing tests with warnings.
	/// </summary>
	public static bool? FailTestsWithWarnings(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<bool?>(TestOptionsNames.Execution.FailTestsWithWarnings);
	}

	/// <summary>
	/// Gets a flag to fail passing tests with warnings. If the flag is not present, returns the
	/// default value (<c>false</c>).
	/// </summary>
	public static bool FailTestsWithWarningsOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		FailTestsWithWarnings(executionOptions) ?? false;

	/// <summary>
	/// Gets the maximum number of threads to use when running tests in parallel.
	/// </summary>
	public static int? MaxParallelThreads(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<int?>(TestOptionsNames.Execution.MaxParallelThreads);
	}

	/// <summary>
	/// Gets the maximum number of threads to use when running tests in parallel. If set to 0 (or not set),
	/// the value of <see cref="Environment.ProcessorCount"/> is used; if set to a value less
	/// than 0, does not limit the number of threads.
	/// </summary>
	public static int MaxParallelThreadsOrDefault(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		var result = executionOptions.MaxParallelThreads();
		if (result is null || result == 0)
			return Environment.ProcessorCount;

		return result.GetValueOrDefault();
	}

	/// <summary>
	/// Gets the parallel algorithm to be used.
	/// </summary>
	public static ParallelAlgorithm? ParallelAlgorithm(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		var parallelAlgorithmString = executionOptions.GetValue<string>(TestOptionsNames.Execution.ParallelAlgorithm);
		return parallelAlgorithmString != null ? (ParallelAlgorithm?)Enum.Parse(typeof(ParallelAlgorithm), parallelAlgorithmString) : null;
	}

	/// <summary>
	/// Gets the parallel algorithm to be used. If the flag is not present, return the default
	/// value (<see cref="ParallelAlgorithm.Conservative"/>).
	/// </summary>
	public static ParallelAlgorithm ParallelAlgorithmOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		ParallelAlgorithm(executionOptions) ?? Sdk.ParallelAlgorithm.Conservative;

	/// <summary>
	/// Gets the value that should be used to seed randomness.
	/// </summary>
	public static int? Seed(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<int?>(TestOptionsNames.Execution.Seed);
	}

	/// <summary>
	/// Gets a flag which indicates if the developer wishes to see output from <see cref="_ITestOutputHelper"/>
	/// live while it's being reported (in addition to seeing it collected together when the test is finished).
	/// </summary>
	public static bool? ShowLiveOutput(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<bool?>(TestOptionsNames.Execution.ShowLiveOutput);
	}

	/// <summary>
	/// Gets a flag which indicates if the developer wishes to see output from <see cref="_ITestOutputHelper"/>
	/// live while it's being reported (in addition to seeing it collected together when the test is finished).
	/// If the flag is not present, returns the default value (<c>false</c>).
	/// </summary>
	public static bool ShowLiveOutputOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		ShowLiveOutput(executionOptions) ?? false;

	/// <summary>
	/// Gets a flag to stop testing on test failure.
	/// </summary>
	public static bool? StopOnTestFail(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<bool?>(TestOptionsNames.Execution.StopOnFail);
	}

	/// <summary>
	/// Gets a flag to stop testing on test failure. If the flag is not present, returns the
	/// default value (<c>false</c>).
	/// </summary>
	public static bool StopOnTestFailOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		StopOnTestFail(executionOptions) ?? false;

	/// <summary>
	/// Gets a flag that determines whether xUnit.net should report test results synchronously.
	/// </summary>
	public static bool? SynchronousMessageReporting(this _ITestFrameworkExecutionOptions executionOptions)
	{
		Guard.ArgumentNotNull(executionOptions);

		return executionOptions.GetValue<bool?>(TestOptionsNames.Execution.SynchronousMessageReporting);
	}

	/// <summary>
	/// Gets a flag that determines whether xUnit.net should report test results synchronously.
	/// If the flag is not set, returns the default value (<c>false</c>).
	/// </summary>
	public static bool SynchronousMessageReportingOrDefault(this _ITestFrameworkExecutionOptions executionOptions) =>
		SynchronousMessageReporting(executionOptions) ?? false;
}
