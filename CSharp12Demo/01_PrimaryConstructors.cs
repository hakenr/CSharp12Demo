namespace PrimaryConstructors;

public class Person(string name, int age)
{
	public string Name { get; } = name;
	public int Age { get; } = age;
}

public class Student(string name, int age, string school) : Person(name, age)
{
	public string School { get; } = school;
}

public class Downloader(HttpClient httpClient)
{
	public string Download(string url)
	{
		return httpClient.GetStringAsync(url).Result;
	}
}




// ================================================================
// See ILSpy

public class ParameterOnly(decimal celsiusTemperature)
{
	private decimal _kelvinTemperature = celsiusTemperature + 273.15m;
	public string Print() => $"Kelvin: {_kelvinTemperature}";
}

public class ClassWithCapture(int id)
{
	public void DoSomething()
	{
		Console.WriteLine($"ID: {id}");
	}

	public void Mutate(int newId)
	{
		id = newId; // constructor parameters are NOT readonly
	}
}


public class DoubleCapture(string name)
{
	public string Name { get; } = name; // 1. stored in a property

	public int GetNameLength()
	{
		return name.Length; // 2. captured in a "<name>P" field
	}

}

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#primary-constructors
// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors