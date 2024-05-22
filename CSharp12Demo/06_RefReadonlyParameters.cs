using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefReadonlyParameters;

public static class Demo
{
	public static void Run()
	{
		int x = 42;
		DoSomething(ref x);
	}

	private static void DoSomething(ref readonly int num)
	{
		// num++;   // CS8331: Cannot assign to variable or use it as the right hand side of a ref assignment because it is a readonly variable
		Console.WriteLine(num);
	}
}

// ref readonly - avoids defensive copy of the value type sometimes created with in

// ref: The argument must be initialized before calling the method. The method can assign a new value to the parameter, but isn't required to do so.
// out: The calling method isn't required to initialize the argument before calling the method. The method must assign a value to the parameter.
// readonly ref: The argument must be initialized before calling the method. The method can't assign a new value to the parameter.
// in: The argument must be initialized before calling the method. The method can't assign a new value to the parameter. The compiler might create a temporary variable to hold a copy of the argument to in parameters.

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#ref-readonly-parameters
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/ref-readonly-parameters
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters#reference-parameters
// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/method-parameters#ref-readonly-modifier
// https://devblogs.microsoft.com/premier-developer/the-in-modifier-and-the-readonly-structs-in-c/