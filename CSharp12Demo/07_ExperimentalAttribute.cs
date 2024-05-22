using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalAttributeDemo
{
	[Experimental("HAKEN001")]
	public class Foo
	{
	}

	public class Demo
	{
		public void Run()
		{
#pragma warning disable HAKEN001
			var f = new Foo();
#pragma warning restore HAKEN001
		}
	}
}
