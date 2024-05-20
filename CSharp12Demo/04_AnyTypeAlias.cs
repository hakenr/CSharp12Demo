using MyPoint = (int X, int Y);
using Temperature = decimal;
using IntArray = int[];

// using StringOption = string?; // Nullable reference type cannot be used as an alias
using StringOptionList = System.Collections.Generic.List<string?>;  // List<> itself is not NRT

using unsafe ArrayPtr = int*;


namespace AnyTypeAlias;

public class Demo
{
	public void Run()
	{
		MyPoint point = (10, 20);
		Console.WriteLine($"Point: {point.X}, {point.Y}");


		Temperature temperature = 37.5m;
		decimal temperature2 = temperature; // Temperature is decimal
		Console.WriteLine($"Temperature: {temperature2}");


		StringOptionList names = [ "Alice", null, "Bob" ];
		IntArray numbers = [ 10, 20, 30 ];
		unsafe
		{
			ArrayPtr ptr = stackalloc int[10];
		}
	}
}

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#alias-any-type
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/using-alias-types
