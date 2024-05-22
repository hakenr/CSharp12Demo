namespace CollectionExpressions;

public class Demo
{
	public void Run()
	{
		// Create an array:
		int[] a = [1, 2, 3, 4, 5, 6, 7, 8];

		// Create a span
		Span<int> b = ['a', 'b', 'c', 'd', 'e', 'f', 'h', 'i'];

		// var x = [1, 2, 3]; // ERROR, there is no target type for the collection expression

		// Create a jagged 2D array:
		int[][] twoD = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

		// Create a jagged 2D array from variables:
		int[] row0 = [1, 2, 3];
		int[] row1 = [4, 5, 6];
		int[] row2 = [7, 8, 9];
		int[][] twoDFromVariables = [row0, row1, row2];


		// spread operator
		int[] c = [0, .. row0, .. row1, -9, -10]; // [0, 1, 2, 3, 4, 5, 6, -9, -10]


		// target-typed compiler optimization
		DoSomething([1, 2, 3]);	 
		DoSomething2([1, 2, 3]);
		DoSomething3([1, 2, 3]);	 
	}

	// see ILSpy

	public void DoSomething(List<int> items)
	{
	}
	
	public void DoSomething2(IEnumerable<int> items)
	{
	}

	public void DoSomething3(ReadOnlySpan<byte> bytes)
	{
	}
}


// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#collection-expressions
// https://devblogs.microsoft.com/dotnet/announcing-csharp-12/#collection-expressions