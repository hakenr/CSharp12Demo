using System.Drawing;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml.Linq;

namespace InlineArrays;

[InlineArray(10)] // known size (compile-time)
public struct MyBuffer10
{
	private int _element0; // Inline array struct must declare one and only one instance field.
}


public static class Demo
{
	public static void Run()
	{
		MyBuffer10 buffer = new MyBuffer10();
		for (int i = 0; i < 10; i++) // no buffer.Length
		{
			buffer[i] = i;
		}

		// can be exposed as a Span/ReadOnlySpan
		Span<int> span = MemoryMarshal.CreateSpan(ref Unsafe.As<MyBuffer10, int>(ref buffer), 10);
		DoSomething(span);
	}

	public static void DoSomething(Span<int> values)
	{
		foreach (var value in values)
		{
			Console.WriteLine(value);
		}
	}
}


public static class Demo2 // corrupted
{
	public static void Run()
	{
		Span<int> values = GetValues();
		foreach (var value in values)
		{
			Console.WriteLine(value);
		}
	}

	public static Span<int> GetValues()
	{
		MyBuffer10 buffer = new MyBuffer10();
		for (int i = 0; i < 10; i++) // no buffer.Length
		{
			buffer[i] = i;
		}

		// ? can be exposed as a Span/ReadOnlySpan ? see the result !
		return MemoryMarshal.CreateSpan(ref Unsafe.As<MyBuffer10, int>(ref buffer), 10);
	}
}

// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-12.0/inline-arrays
// Used in the runtime for performance-critical scenarios, e.g. collection expressions.