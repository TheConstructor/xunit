using System.Collections.Generic;
using Xunit.Sdk;

namespace Xunit.v3;

/// <summary>
/// An implementation of <see cref="IEqualityComparer{T}"/> for <see cref="ITestMethod"/>.
/// Compares the names of the methods.
/// </summary>
public class TestMethodComparer : IEqualityComparer<ITestMethod?>
{
	/// <summary>
	/// The singleton instance of the comparer.
	/// </summary>
	public static readonly TestMethodComparer Instance = new();

	/// <inheritdoc/>
	public bool Equals(
		ITestMethod? x,
		ITestMethod? y)
	{
		if (x is null && y is null)
			return true;
		if (x is null || y is null)
			return false;

		return x.UniqueID == y.UniqueID;
	}

	/// <inheritdoc/>
	public int GetHashCode(ITestMethod? obj) =>
		obj is null ? 0 : obj.MethodName.GetHashCode();
}
