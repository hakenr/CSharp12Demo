namespace DefaultLambdaParameters;

public static class Demo
{
	public static void Run()
	{
		var increment = (int source, int increment = 1) => source + increment;

		Console.WriteLine(increment(5)); // 6
		Console.WriteLine(increment(5, 2)); // 7
	}
}

// https://devblogs.microsoft.com/dotnet/announcing-csharp-12/#default-lambda-parameters